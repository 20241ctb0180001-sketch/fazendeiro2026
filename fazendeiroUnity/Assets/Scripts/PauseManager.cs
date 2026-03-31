using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject Confirmarsaida;
    [SerializeField] private bool empause = false;

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
        if(pauseActionUI.WasPressedThisFrame())
        {
            if (pauseActionPlayer.WasCompletedThisFrame())
            {
                ContJogo();
                InputActions.FindActionMap("Player").Disable();
                InputActions.FindActionMap("UI").Enable();                
            }
            else if(pauseActionUI.WasPressedThisFrame())
            {
                PausaJogo();
                InputActions.FindActionMap("Player").Enable();
                InputActions.FindActionMap("UI").Disable(); 
            }
        }
    }

    public void PausaJogo(){
        Debug.Log("pausa");
        empause = true;
        Time.timeScale = 0f;
        if(PausePanel) PausePanel.SetActive(true);
    }

    public void ContJogo(){
        Debug.Log("despausa");
        empause = false;
        Time.timeScale = 1f;
        if(PausePanel) PausePanel.SetActive(false);
                Confirmarsaida.SetActive(false);

    }
    
    public void Confirmacao()
    {
        Confirmarsaida.SetActive(true);
    }
}
