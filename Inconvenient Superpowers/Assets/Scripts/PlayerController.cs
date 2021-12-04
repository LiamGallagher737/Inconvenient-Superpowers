using UnityEngine; using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    [Header("Basic Stuff")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform cam;
    public float jumpForce = 4f;
    public float movementSpeed = 50f;
    public Text scoreText;
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    [Header("Edge Loop")]
    [SerializeField] private float edgePos = 9f;
    [Header("Death")] 
    [SerializeField] private float deathPoint = -7.22f;
    [Header("Audio")]
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioSource audioSource;
    
    private float input;
    private bool jump;
    public static float highestScore;
    
    private InputActions inputActions;
    private InputActions InputActions{
        get{
            if(inputActions != null){return inputActions;}
            return inputActions = new InputActions();
        }
    }

    private void Start() {
        InputActions.Player.Movement.performed += ctx => { input = ctx.ReadValue<float>(); };
        InputActions.Player.Movement.canceled += ctx => { input = 0f; };

        InputActions.Player.Jump.performed += ctx => { jump = true; };
        InputActions.Player.Jump.canceled += ctx => { jump = false; };

        cam = Camera.main.transform;
        highestScore = 0;
    }

    private void OnEnable() => InputActions.Enable();
    private void OnDisable() => InputActions.Disable();

    private void Update() {
        if (GameManager.GameOver) return;

        if (highestScore < transform.position.y) {
            highestScore = transform.position.y;
            scoreText.text = (highestScore+1.45f).ToString("F1");
        }
        
        if (transform.position.y < cam.position.y + deathPoint) {
            GameManager.PlayerDied();
        }
        
        if (transform.position.x < -edgePos) {
            transform.position = new Vector3(edgePos, transform.position.y, transform.position.z);
        }else if (transform.position.x > edgePos) {
            transform.position = new Vector3(-edgePos, transform.position.y, transform.position.z);
        }
        
        if (jump && IsTouchingGround()) { // Jumping
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpSFX);
            jump = false;
        }
        
        if (input == 0f) return;
        rb.AddForce(Vector2.right * input * Time.deltaTime * movementSpeed, ForceMode2D.Impulse);
    }
    
    private bool IsTouchingGround() {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, groundLayer);
    }
}
