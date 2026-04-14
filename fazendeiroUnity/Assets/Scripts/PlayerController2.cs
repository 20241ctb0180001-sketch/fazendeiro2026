using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    public GameObject ghost;
    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction GhostAction;
    private int maxVida = 3;
    public int vida;
    public VIdaUI vidaUI;
    public bool transparente = false;

     private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        GhostAction = InputSystem.actions.FindAction("Crouch");
        ghost = GameObject.Find("Player/SF_Character_FarmersWife");
        vida = maxVida;
        vidaUI.SetMaxHearts(maxVida);

        if (Application.platform != RuntimePlatform.Android){
            GameObject.Find("Move Button").SetActive(false);
            GameObject.Find("attackButton").SetActive(false);
            GameObject.Find("GhostButton").SetActive(false);
        } 
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

    }

    private IEnumerator Ghost(float wait)
    {
        Debug.Log("transparente");
        yield return new WaitForSeconds(wait);
        transparente = false;
        ghost.SetActive(true);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Animal"))
        {
            if(transparente == true){
                vida=vida;
                vidaUI.UpdateHearts(vida);
            }else{
                vida -= 1;
                vidaUI.UpdateHearts(vida);
                Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
                if(vida <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }   
            }

        }
    }
}