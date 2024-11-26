using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using System.Collections.Generic;

public class Player : MonoBehaviour
{    [SerializeField] int playerSpeed;
    [SerializeField] float hLim;
    [SerializeField] float VLim;
    Rigidbody2D rb;
    Vector2 playerMove;

    // chamando outros scriptsVV

    SmudgeManager smudgeManager;
    Score score;

    // nao chamando scriptoss
    

    private List<GameObject> smudges = new List<GameObject>();

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        smudgeManager = GameObject.Find("SmudgeManager").GetComponent<SmudgeManager>();
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        transform.position += new Vector3(playerMove.x, playerMove.y, 0) * playerSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -VLim, VLim), 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -hLim, hLim), transform.position.y, 0);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("FallingObject"))
            Debug.Log("caiu algo na minha cabeça");

        if (collider.CompareTag("Smudge")) smudges.Add(collider.gameObject);

    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Smudge")) smudges.Remove(collider.gameObject);
    }

    public void OnMoveHorizontal(CallbackContext context)
    {
        playerMove = new Vector2(context.ReadValue<float>(), playerMove.y);
    }

    public void OnMoveVertical(CallbackContext context)
    {
        playerMove = new Vector2(playerMove.x, context.ReadValue<float>());
    }

    public void OnClean(CallbackContext context)
    {
        foreach (GameObject smudge in smudges)
        {
            smudgeManager.CreateSmudge();
            Destroy(smudge);
            score.ScoreOnePoint();
        }
    }
}
