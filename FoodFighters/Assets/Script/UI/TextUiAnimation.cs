using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TextUiAnimation : MonoBehaviour
{
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void MakeTransition()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        transform.localPosition = new Vector3(-1000f,0f, 0f);
        yield return rectTransform.DOAnchorPos(new Vector2(0f, 0f), 0.4f, false).SetEase(Ease.OutQuart).WaitForCompletion();
        yield return transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.8f).SetLoops(4, LoopType.Yoyo).WaitForCompletion();
        yield return rectTransform.DOAnchorPos(new Vector2(1000f, 0f), 0.4f, false).SetEase(Ease.OutQuart).WaitForCompletion();
    }
}
