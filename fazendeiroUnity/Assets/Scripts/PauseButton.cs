using UnityEngine;
using UnityEngine.InputSystem;


public class PauseButton : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction PauseAction;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        PauseAction = InputSystem.actions.FindAction("Pause");
    }
    void Update()
    {
        
    }
}
