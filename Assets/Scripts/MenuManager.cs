using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using DG.Tweening;
using Unity.Mathematics;

public class MenuManager : MonoBehaviour
{
    [SerializeField] float rotationValue;
    [SerializeField] float rotationHalfTime;
    [SerializeField] float zoomHalfTime;
    [SerializeField] float zoomValue;
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 0, rotationValue), rotationHalfTime, RotateMode.Fast).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        transform.DOScale(new Vector3(zoomValue, zoomValue, 0), zoomHalfTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
    public void OnClickStartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

}
