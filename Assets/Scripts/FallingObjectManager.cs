using UnityEngine;

public class FallingObjectManager : MonoBehaviour
{
    [SerializeField] GameObject fallingObject;
    [SerializeField] float spawnMin;
    [SerializeField] float spawnMax;
    [SerializeField] Sprite[] fallingObjectSprites;
    [SerializeField] AudioClip sonzinho;
    GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void CreateFallingObject()
    {
        GameObject fallingObjectInstance = Instantiate(
            fallingObject,
            new Vector3(Random.Range(spawnMin, spawnMax), 13, 0),
            Quaternion.identity
        );
        SpriteRenderer fallingObjectSprite = fallingObjectInstance.GetComponent<SpriteRenderer>();
        fallingObjectSprite.sprite = fallingObjectSprites[Random.Range(0, fallingObjectSprites.Length)];
        gameManager.PlaySound(sonzinho);
    }
}
