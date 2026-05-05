using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Placar : MonoBehaviour
{
    [SerializeField] private int Npontos = 0;
    private int Nstars = 0;
    [SerializeField] private TextMeshProUGUI textPontos;
    [SerializeField] private TextMeshProUGUI textStars;
    public int pontos;
    public int estrelas;
    [SerializeField] private int requiredStars = 3;
    private bool menuLoaded = false;

    public void AddPoints(int points){
        Npontos = Npontos + points;
        textPontos.text = ": "+Npontos.ToString();
        pontos = Npontos;
    }

    public void AddStars(int stars){
        Nstars = Nstars + stars;
        textStars.text = " "+ Nstars.ToString();
        estrelas = Nstars;
    }

    public void Update(){
            if (estrelas >= requiredStars && !menuLoaded)
            {
                menuLoaded = true;
                SceneManager.LoadScene("Win");
            }
    }
}