using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public Text textPontos;
    private int Npontos = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Animal")){
        Destroy(gameObject);
        Destroy(other.gameObject);
        AddPoints();;
        }
    }

    public void AddPoints(){
        Npontos += 50;
        textPontos.text = ": "+Npontos.ToString();
    }
}
