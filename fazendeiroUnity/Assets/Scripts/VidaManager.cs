using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaManager : MonoBehaviour
{
    public PlayerController2 player;
    public VIdaUI vidaui;
    private int maxVida = 3;
    public int vida;
    void Awake()
    {
        vida = maxVida;
        vidaui.SetMaxHearts(maxVida);   
    }

    public void OnTriggerEnter(UnityEngine.Collider collider)
    {
        if(collider.gameObject.CompareTag("Animal"))
        {
            if(player.transparente == true){
                vidaui.UpdateHearts(vida);
            }else{
                vida -= 1;
                vidaui.UpdateHearts(vida);
                if(vida <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}
