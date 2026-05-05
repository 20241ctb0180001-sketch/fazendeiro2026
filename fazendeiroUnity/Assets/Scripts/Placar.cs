using UnityEngine;
using TMPro;
public class Placar : MonoBehaviour
{
    [SerializeField] private int Npontos = 0;
    [SerializeField] private TextMeshProUGUI textPontos;
    public int pontos;

        public void AddPoints(int points){
        Npontos = Npontos + points;
        textPontos.text = ": "+Npontos.ToString();
        pontos = Npontos;
    }
}