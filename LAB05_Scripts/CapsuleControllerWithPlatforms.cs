using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleControllerWithPlatforms : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 2f;
    public float jumpHeight = 2f;
    private CharacterController controller;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGrounded;
    private Vector2 moveInput;
    private Vector2 lookInput;

    // movingPlatform
    private MovingPlatform currentPlatform;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Sprawdzamy, czy postaæ stoi na ziemi
        isGrounded = controller.isGrounded;

        // MovingPlatform code START
        RaycastHit hit;
        float distance = controller.height / 2 + 0.05f;
        if (Physics.SphereCast(transform.position, controller.radius * 0.9f, Vector3.down, out hit, distance))
        {
            MovingPlatform mp = hit.collider.GetComponent<MovingPlatform>();
            currentPlatform = mp;
        }
        else
        {
            currentPlatform = null;
        }
        // MovingPlatform code END

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Ruch postaci na podstawie wartoœci moveInput
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        // ew poprawka
        // Vector3 move = transform.TransformDirection(new Vector3(moveInput.x, 0, moveInput.y));
        //controller.Move(move * speed * Time.deltaTime); // comment if using code between "movingPlatform"

        // MovingPlatform code START
        Vector3 platformMove = Vector3.zero;
        if (currentPlatform != null)
        {
            platformMove = currentPlatform.delta; // delta w jednostkach na klatkê
        }

        controller.Move(move * speed * Time.deltaTime + platformMove);
        // MovingPlatform code END

        // Obrót postaci (wokó³ osi Y)
        transform.Rotate(Vector3.up * lookInput.x * lookSpeed);

        // Grawitacja
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnMove(InputValue movementValue)
    {
        // Pobieramy dane ruchu (x i y) z wejœcia
        moveInput = movementValue.Get<Vector2>();
    }

    private void OnJump(InputValue movementValue)
    {
        // Jeœli postaæ jest na ziemi, ustawiamy prêdkoœæ skoku
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void OnLook(InputValue lookValue)
    {
        lookInput = lookValue.Get<Vector2>();
    }

}