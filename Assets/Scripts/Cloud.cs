using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour
{
    [SerializeField] RawImage imagem;
    [SerializeField] float _x;
 
    void Update()
    {
        imagem.uvRect = new Rect(imagem.uvRect.position + new Vector2(_x,0) * Time.deltaTime,imagem.uvRect.size);
    }

}
