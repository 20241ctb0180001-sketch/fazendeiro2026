using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]private GameObject Painel;
    [SerializeField]private GameObject PainelOpcoes;
    public void Jogar()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Opcoes()
    {
        Painel.SetActive(false);
        PainelOpcoes.SetActive(true);
    }

    public void Voltar()
    {
        Painel.SetActive(true);
        PainelOpcoes.SetActive(false);
    }

    public void Sair()
    {
        Debug.Log("saindo");
        Application.Quit();
    }
}
