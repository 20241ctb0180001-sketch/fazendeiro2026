using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private Placar placar;
    public int stars;

    private void Awake()
    {
        placar = GameObject.Find("Placar").GetComponent<Placar>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Animal")){
        Destroy(gameObject);
        Destroy(other.gameObject);
        placar.AddPoints(50);
        }
        if(other.CompareTag("Estrela")){
        Destroy(gameObject);
        Destroy(other.gameObject);
        stars++;
        }

    }
}
