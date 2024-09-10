using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public Transform cameraTransform;
    public float mouseSensitivity = 125f;
    private Rigidbody rb;
    private float xRotation = 0f;

    [Header("Movimentação")]
    public float moveX;
    public float moveY;
    public float moveSpeedNow;
    public float runSpeed;

    [Header("Stamina")]
    public float stamina;
    public bool delaySemStamina;
    public Image[] barraDeStamina;
    public GameObject staminaObj;

    [Header("Componentes")]
    public Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        Cursor.lockState = CursorLockMode.Locked;

        //Status iniciais
        runSpeed = 1.7f * moveSpeed; //Velocidade correndo = 2x velocidade andando.
        moveSpeedNow = moveSpeed; //Starta com a velocidade atual = velocidade andando.
        stamina = 100; //Starta com stamina máxima.
    }

    private void Update()
    {
        Stamina();
        RotateCamera();
        //Sounds();
    }

    private void FixedUpdate()
    {
        Move();
        Run();
    }

    private void Move()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * moveY + right * moveX;
        movement *= moveSpeedNow * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift) && !((moveY < 0 && moveX == 0) || (moveY < 0 && moveX > 0) || ((moveY < 0 && moveX < 0)))) //Verifica se esta tentando correr de costas.
        {
            if(stamina > 0 && !delaySemStamina) moveSpeedNow = runSpeed; //Habilita a velocidade de corrida.
        }
        else
        {
            moveSpeedNow = moveSpeed; //Mantem a velocidade de caminhada.
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeedNow = moveSpeed; //Retorna a velocidade de caminhada.
        }
    }

    private void Stamina()
    {
        if(moveSpeedNow == runSpeed)
        {
            if(stamina >= 0)    stamina -= Time.deltaTime*20; // Viana alterou a stamina gasta

            cam.fieldOfView += Time.deltaTime*80; //Aceleracao de aumento de fov ao correr.

            if(cam.fieldOfView >= 70)   cam.fieldOfView = 70; //Declaração de Fov máximo.
        }
        if(moveSpeedNow == moveSpeed){

            cam.fieldOfView -= Time.deltaTime*20; //Decaimento de Fov ao não correr.

            if(cam.fieldOfView <= 60)   cam.fieldOfView = 60; //Declaração de Fov mínimo.

            if(stamina >= 100) //Verificação de stamina máxima.
            {
                moveSpeedNow = moveSpeed; 
                stamina = 100;
            }
            else
            {
                stamina += Time.deltaTime*15; //Recuperação de stamina de forma linear.

                if(stamina >= 100)  //Verificação de stamina máxima.
                {
                    stamina = 100;
                    delaySemStamina = false;
                }
            }
        }
        if(stamina <= 0) //Verificação de stamina mínima.
        {
            moveSpeedNow = moveSpeed;
            delaySemStamina = true; //Delay de recuperação ao atingir stamina mínima.
        }
        if(stamina >= 100) staminaObj.SetActive(false);
        else staminaObj.SetActive(true);
        barraDeStamina[0].fillAmount = (float)stamina / 100; //Atualiza o HUD da barra de Stamina.
        barraDeStamina[1].fillAmount = (float)stamina / 100; //Atualiza o HUD da barra de Stamina.
    }
}