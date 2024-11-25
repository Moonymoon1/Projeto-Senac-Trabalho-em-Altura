using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int playerSpeed;
    [SerializeField] float hLim;
    [SerializeField] float VLim;
    Rigidbody2D rb;
    SmudgeManager smudgeManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        smudgeManager = GameObject.Find("SmudgeManager").GetComponent<SmudgeManager>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += new Vector3(input.x, input.y, 0) * playerSpeed * Time.deltaTime;
        transform.position = new Vector3 (transform.position.x, Mathf.Clamp(transform.position.y, -VLim, VLim), 0);
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -hLim, hLim), transform.position.y, 0);
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
            if(Input.GetKey(KeyCode.Space))
            {
                Debug.Log("limpei uma janelinha");   
                smudgeManager.CreateSmudge(); 
                Destroy(collider.gameObject);
            }
                
        }
    }
    
}
