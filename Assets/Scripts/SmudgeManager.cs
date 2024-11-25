using UnityEngine;

public class SmudgeManager : MonoBehaviour
{
    [SerializeField] GameObject smudge;
    public void CreateSmudge()
    {
        GameObject smudgeInstance = Instantiate(smudge, new Vector3(Random.Range(-18,18), Random.Range(-11,11), 0), Quaternion.identity);
    }
}
