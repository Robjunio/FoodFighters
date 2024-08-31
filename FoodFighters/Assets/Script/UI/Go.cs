using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Go : MonoBehaviour
{
    private Image Image;

    private void Start()
    {
        Image = GetComponent<Image>();
    }
    public void UpdateGo()
    {
        if (Image != null)
        {
            Image.enabled = true;
        }
        transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.8f).SetLoops(8, LoopType.Yoyo).OnComplete(() => {
            Image.enabled = false;
        });
        
    }
}
