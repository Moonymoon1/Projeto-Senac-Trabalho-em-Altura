using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] int playerSpeed;
    [SerializeField] private Vector2 maxLim;
    [SerializeField] private Vector2 minLim;
    Rigidbody2D rb;
    Vector2 playerMove;
    SmudgeManager smudgeManager;
    GameManager gameManager;
    Score score;

    private List<GameObject> smudges = new List<GameObject>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        smudgeManager = GameObject.Find("SmudgeManager").GetComponent<SmudgeManager>();
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        transform.position += new Vector3(playerMove.x, playerMove.y, 0) * playerSpeed * Time.deltaTime;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minLim.x, maxLim.x),
            Mathf.Clamp(transform.position.y, minLim.y, maxLim.y),
            0
        );
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("FallingObject"))
            {
                gameManager.GameOver();
            }

        if (collider.CompareTag("Smudge")) smudges.Add(collider.gameObject);

    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Smudge") && smudges.Contains(collider.gameObject))
            smudges.Remove(collider.gameObject);
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
        if (!context.performed || smudges.Count == 0) return;
        GameObject smudge = smudges[^1];
        smudgeManager.CreateSmudge();
        score.ScoreOnePoint();
        Destroy(smudge);
    }
}
