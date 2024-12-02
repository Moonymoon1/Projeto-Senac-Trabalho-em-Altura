using UnityEngine;

public class SmudgeManager : MonoBehaviour
{
    [SerializeField] private GameObject smudge;
    [SerializeField] private Vector2 smudgeSpawnMin;
    [SerializeField] private Vector2 smudgeSpawnMax;
    [SerializeField] private Sprite[] smudgeSprites;
    [SerializeField] AudioClip sonzinho;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void CreateSmudge()
    {
        
        GameObject smudgeInstance = Instantiate(
            smudge,
            new Vector3(Random.Range(smudgeSpawnMin.x, smudgeSpawnMax.x),
            Random.Range(smudgeSpawnMin.y, smudgeSpawnMax.y), 0),
            Quaternion.identity
        );
        SpriteRenderer smudgeSprite = smudgeInstance.GetComponent<SpriteRenderer>();
        smudgeSprite.sprite = smudgeSprites[Random.Range(0, smudgeSprites.Length)];
        gameManager.PlaySound(sonzinho);
    }
}
