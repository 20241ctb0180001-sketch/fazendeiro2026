using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject Confirmarsaida;
    [SerializeField] private bool empause = false;
    public DetectCollisions detect;

    public InputActionAsset InputActions;
    private InputAction pauseActionUI;
    private InputAction pauseActionPlayer;

    private void Awake(){
        Confirmarsaida.SetActive(false);
        pauseActionPlayer = InputSystem.actions.FindAction("Player/Pause");
        pauseActionUI = InputSystem.actions.FindAction("UI/Pause");
        if(PausePanel)
            PausePanel.SetActive(false);
        empause = false;
        Time.timeScale = 1f;
    }

    private void Update(){
            if (pauseActionPlayer.WasPressedThisFrame()||pauseActionUI.WasPressedThisFrame())
            {
                empause = !empause;
            if (empause == true)
                {
                    PausaJogo();
            }else if(empause == false)
                {
                    ContJogo();
                }
            }

            if(detect.stars >= 5)
            {
                SceneManager.LoadScene("Menu");
            }
    }

    public void PausaJogo(){
        Debug.Log("pausa");
        Time.timeScale = 0f;
        if(PausePanel) PausePanel.SetActive(true);
        InputActions.FindActionMap("Player").Disable();
        InputActions.FindActionMap("UI").Enable(); 
    }

    public void ContJogo(){
        Debug.Log("despausa");
        Time.timeScale = 1f;
        InputActions.FindActionMap("Player").Enable();
        InputActions.FindActionMap("UI").Disable(); 
        if(PausePanel) PausePanel.SetActive(false);
            Confirmarsaida.SetActive(false); 
    }
    
    public void Confirmacao()
    {
        Confirmarsaida.SetActive(true);
    }

    public void Sair()
    {
        Debug.Log("saindo");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
