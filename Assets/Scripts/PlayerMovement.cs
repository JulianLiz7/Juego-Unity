using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float walkSpeed = 4f;
    public float sprintSpeed = 6f;
    public float jumpHeight = 2f;
    public float gravity = -20f;
    public float rotationSpeed = 10f;
<<<<<<< HEAD
=======
    public float mouseSensitivity = 1f;
>>>>>>> a2541d0bfbd3fa12b02325e69536126a95f62ce8

    [Header("Referencias")]
    public Transform cameraTransform;
    public Animator animator;

    private CharacterController controller;
    private Vector3 velocity;
    private float currentSpeed;
<<<<<<< HEAD
=======
    private float yaw;
>>>>>>> a2541d0bfbd3fa12b02325e69536126a95f62ce8

    public bool IsGrounded { get; private set; }
    public bool IsMoving { get; private set; }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
<<<<<<< HEAD
        Cursor.visible = false;
=======
>>>>>>> a2541d0bfbd3fa12b02325e69536126a95f62ce8

        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        UpdateAnimator();
    }

    void HandleMovement()
    {
        IsGrounded = controller.isGrounded;

<<<<<<< HEAD
        if (IsGrounded && velocity.y < 0)
            velocity.y = -2f;

=======
        // Mantener pegado al suelo
        if (IsGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Input movimiento
>>>>>>> a2541d0bfbd3fa12b02325e69536126a95f62ce8
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;
        IsMoving = inputDirection.magnitude >= 0.1f;

        Vector3 moveDirection = Vector3.zero;

        if (IsMoving)
        {
            moveDirection = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f) * inputDirection;
            bool isSprinting = Input.GetKey(KeyCode.LeftShift);
            currentSpeed = isSprinting ? sprintSpeed : walkSpeed;
        }

        // Salto
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("isJumping", true);
        }

<<<<<<< HEAD
        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMovement = (moveDirection * currentSpeed) * Time.deltaTime;
        finalMovement.y += velocity.y * Time.deltaTime;

        controller.Move(finalMovement);

=======
        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;

        // Movimiento final
        Vector3 finalMovement = (moveDirection * currentSpeed) * Time.deltaTime;
        finalMovement.y += velocity.y * Time.deltaTime;
        controller.Move(finalMovement);

        // Reset salto al tocar suelo
>>>>>>> a2541d0bfbd3fa12b02325e69536126a95f62ce8
        if (IsGrounded && velocity.y < 0f)
            animator.SetBool("isJumping", false);
    }

    void HandleRotation()
    {
<<<<<<< HEAD
        if (IsMoving)
        {
            // Rotar SOLO al moverse (Estilo Fortnite)
            Vector3 forward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
=======
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        yaw += mouseX;

        if (IsMoving)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, yaw, 0f), rotationSpeed * Time.deltaTime);
>>>>>>> a2541d0bfbd3fa12b02325e69536126a95f62ce8
    }

    void UpdateAnimator()
    {
        float speedPercent = IsMoving ? (currentSpeed == sprintSpeed ? 1f : 0.5f) : 0f;
        animator.SetFloat("Speed", speedPercent, 0.1f, Time.deltaTime);
        animator.SetBool("IsGrounded", IsGrounded);
        animator.SetFloat("VerticalVelocity", velocity.y);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> a2541d0bfbd3fa12b02325e69536126a95f62ce8
