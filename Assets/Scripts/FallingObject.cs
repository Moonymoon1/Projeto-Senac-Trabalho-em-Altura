using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] float fallingSpeed;
    [SerializeField] float accelerationSpeed;
    [SerializeField] int rotationSpeed;
    FallingObjectManager manager;

    void Start()
    {
        manager = GameObject.Find("FallingObjectManager").GetComponent<FallingObjectManager>();
    }

    void Update()
    {
        Cair();
    }

    private void Cair()
    {
        transform.position += new Vector3(0, 1, 0) * fallingSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        fallingSpeed += accelerationSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy(gameObject);
        manager.CreateFallingObject();
    }
}


