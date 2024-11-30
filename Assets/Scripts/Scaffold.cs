using UnityEngine;

public class Scaffold : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float playerHeightDiff;

    void Update()
    {
        ScaffoldMovement();
    }

    private void ScaffoldMovement()
    {
        Vector3 playerPosition = playerTransform.position;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, playerPosition.y + playerHeightDiff, pos.z);
    }

}
