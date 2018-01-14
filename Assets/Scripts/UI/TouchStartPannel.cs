using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TouchStartPannel : MonoBehaviour {

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
    }

    public void StopBlink() {
        mySequence.Kill();
    }
   
}
