using System;
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
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction GhostAction;
    public int vidaMax =3;
    int vidaAtual;

     private void Awake()
    {
        vidaAtual = vidaMax;
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        GhostAction = InputSystem.actions.FindAction("Crouch");
        ghost =  GameObject.Find("Player/SF_Character_FarmersWife");

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
            StartCoroutine(Ghost(2));
        }

    }

    void DanoRecebido(int dano)
    {
        vidaAtual = Math.Clamp(vidaAtual + dano,0, vidaMax);
        Debug.Log(vidaAtual + "/" + vidaMax);

    }

    private IEnumerator Ghost(float wait)
    {
        Debug.Log("transparente");
        yield return new WaitForSeconds(wait);
        ghost.SetActive(true);
    }
}
