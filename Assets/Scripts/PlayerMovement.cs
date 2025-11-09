using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;            // Velocidad de movimiento
    public float rotationSpeed = 10f;   // Suavidad de giro
    public float jumpHeight = 2f;       // Altura del salto
    public float gravity = -9.81f;      // Gravedad personalizada
    public Transform cameraTransform;   // Referencia a la cámara

    private CharacterController controller;
    private float turnSmoothVelocity;
    private Vector3 velocity;           // Controla la velocidad vertical
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Si no se asigna cámara, usa la principal
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Detectar si está en el suelo
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f; // mantenerlo pegado al suelo

        // Movimiento según cámara
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDir.magnitude >= 0.1f)
        {
            // Calcula ángulo según la cámara
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSpeed * Time.deltaTime);

            // Gira el personaje
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Mueve según la dirección de la cámara
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Salto (con tecla Espacio)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
