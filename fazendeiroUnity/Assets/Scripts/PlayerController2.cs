using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    public GameObject ghost;
    public InputActionAsset InputActions;
    private InputAction moveAction, fireAction, GhostAction, Meowaction;
    public bool transparente = false;
    private AudioSource source;
    public AudioClip MEOW;
    public Placar placar;
     private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        GhostAction = InputSystem.actions.FindAction("Crouch");
        ghost = GameObject.Find("Player/SF_Character_FarmersWife");
        Meowaction = InputSystem.actions.FindAction("Meow");

        if (Application.platform != RuntimePlatform.Android){
            GameObject.Find("Move Button").SetActive(false);
            GameObject.Find("attackButton").SetActive(false);
            GameObject.Find("GhostButton").SetActive(false);
            GameObject.Find("MeowButton").SetActive(false);
        } 

        source = GetComponent<AudioSource>();
    }
    
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    void Update()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }

        if (fireAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        if(GhostAction.WasPressedThisFrame())
        {
            ghost.SetActive(false);
            transparente = true;
            StartCoroutine(Ghost(2));
        }
        
        if (Meowaction.WasPressedThisFrame())
        {
            source.PlayOneShot(MEOW, 1.0f);
            placar.AddPoints(10);
        }
    }

    private IEnumerator Ghost(float wait)
    {
        Debug.Log("transparente");
        yield return new WaitForSeconds(wait);
        transparente = false;
        ghost.SetActive(true);
    }
}