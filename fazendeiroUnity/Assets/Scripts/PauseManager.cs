using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private bool empause = false;

    public InputActionAsset InputActions;
    private InputAction pauseAction;

    private void Awake(){
        pauseAction = InputSystem.actions.FindAction("Pause");
        if(PausePanel)
            PausePanel.SetActive(false);
        empause = false;
        Time.timeScale = 1f;
    }

    private void Update(){
        if(pauseAction.WasPressedThisFrame())
        {
            if(empause)
                ContJogo();
            else
                PausaJogo();
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
    }
}
