using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    [SerializeField] InputActions playerInputActions;
    [SerializeField] int playerSpeed;
    [SerializeField] float hLim;
    [SerializeField] float VLim;
    Rigidbody2D rb;
    SmudgeManager smudgeManager;
    Vector2 playerMove;
    private 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        smudgeManager = GameObject.Find("SmudgeManager").GetComponent<SmudgeManager>();

        playerInputActions.Player.MoveHorizontal.performed += OnMoveHorizontal;
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        // Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += new Vector3(playerMove.x, playerMove.y, 0) * playerSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -VLim, VLim), 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -hLim, hLim), transform.position.y, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FallingObject"))
        {
            Debug.Log("caiu algo na minha cabeça");
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Smudge"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("limpei uma janelinha");
                smudgeManager.CreateSmudge();
                Destroy(collider.gameObject);
            }
        }
    }

    public void OnMoveHorizontal(CallbackContext context)
    {
        playerMove = new Vector2(context.ReadValue<float>(), playerMove.y);
    }

    public void OnMoveVertical(CallbackContext context)
    {
        playerMove = new Vector2(playerMove.x, context.ReadValue<float>());
    }

    public void OnInteract(CallbackContext context)
    {
        Debug.Log("Interagindo");
    }
}
