using UnityEngine;

public class FallingObjectManager : MonoBehaviour
{
    [SerializeField] GameObject fallingObject;

    public void CreateFallingObject()
    {
        GameObject fallingObjectInstance = Instantiate(fallingObject, new Vector3(Random.Range(-18,18), 13, 0), Quaternion.identity);
    }
}
