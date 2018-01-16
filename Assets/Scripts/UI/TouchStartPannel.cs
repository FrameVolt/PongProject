using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TouchStartPannel : MonoBehaviour {
    [SerializeField]
    private CountDownPannel countDownPanel;

    private Text text;
    private Sequence mySequence;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
    private void Start()
    {
        mySequence = DOTween.Sequence();
        mySequence.SetDelay(1);
        mySequence.Append(text.DOFade(0, 0.5f));
        mySequence.Append(text.DOFade(1, 0.5f));
        mySequence.SetLoops(-1);
        EventService.Instance.GetEvent<GameActiveEvent>().Subscribe(StopBlink);
    }

    public void StopBlink() {
        mySequence.Kill();
        text.DOFade(0, 0.5f);
        countDownPanel.StartCount();
    }
}
