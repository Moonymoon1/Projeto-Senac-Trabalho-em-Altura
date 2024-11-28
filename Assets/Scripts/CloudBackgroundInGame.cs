using Unity.VisualScripting;
using UnityEngine;

public class CloudBackgroundInGame : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Renderer bgRenderer;

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed*Time.deltaTime,0);
    }
}
