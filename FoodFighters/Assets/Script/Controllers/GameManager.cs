using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextUiAnimation textAnim;
    [SerializeField] GameObject dreamObject;
    [SerializeField] Go UIGo;
    public static GameManager instance;
    public bool GameStarted;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Camera.main.transform.DOShakePosition(4f, 0.1f, 15, 45);

        dreamObject.transform.DOMoveY(0, 4f).SetEase(Ease.InOutSine).OnComplete(() => {
            textAnim.MakeTransition();
            dreamObject.transform.DOMoveY(0.2f, 1f).SetLoops(-1, LoopType.Yoyo).Play();
            GameStarted = true;

            Invoke("UpdateUI", 3f);
        });
    }

    void UpdateUI()
    {
        UIGo.gameObject.SetActive(true);
        UIGo.UpdateGo();
    }
}
