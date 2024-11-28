using UnityEngine;

public class SmudgeManager : MonoBehaviour
{
    [SerializeField] private GameObject smudge;
    [SerializeField] private Vector2 smudgeSpawnMin;
    [SerializeField] private Vector2 smudgeSpawnMax;
    [SerializeField] private Sprite[] smudgeSprites;
    public void CreateSmudge()
    {
        // GameObject smudgeInstance = Instantiate(smudge, new Vector3(Random.Range(-18,18), Random.Range(-11,11), 0), Quaternion.identity);
        GameObject smudgeInstance = Instantiate(
            smudge,
            new Vector3(Random.Range(smudgeSpawnMin.x, smudgeSpawnMax.x),
            Random.Range(smudgeSpawnMin.y, smudgeSpawnMax.y), 0),
            Quaternion.identity
        );
        SpriteRenderer smudgeSprite = smudgeInstance.GetComponent<SpriteRenderer>();
        smudgeSprite.sprite = smudgeSprites[Random.Range(0, smudgeSprites.Length)];
    }
}
