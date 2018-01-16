using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class CountDownPannel : MonoBehaviour {

    private Text text;
    

    private void Awake()
    {
        text = GetComponent<Text>();
        text.enabled = false;
        EventService.Instance.GetEvent<PlayerRegoEvent>().Subscribe(ReGoCount);
        EventService.Instance.GetEvent<PingPongDeadEvent>().Subscribe(PingPongDead);
    }


    public void StartCount()
    {
        StartCoroutine(DoStartCount());
    }
    private void PingPongDead() {
        text.enabled = true;
        transform.localScale = Vector3.one;
        text.DOFade(1, 0f);
        text.text = "Ready";
    }
    private void ReGoCount() {
        StartCoroutine(DoReGoCount());
    }

    private IEnumerator DoReGoCount()
    {
        text.enabled = true;
        yield return StartCoroutine(Fade("Ready"));
        GameManager.Instance.PlayerRunEvent();
        yield return StartCoroutine(Fade("GO"));
        text.enabled = false;
        
    }



    private IEnumerator DoStartCount () {
        text.enabled = true;
        int index = 3;
        for (int i = index; i > 0; i--)
        {
            yield return StartCoroutine(Fade(i.ToString()));
        }
        GameManager.Instance.PlayerRunEvent();
        yield return StartCoroutine(Fade("GO"));
        text.enabled = false;
        
    }

    private IEnumerator Fade(string index) {
        transform.localScale = Vector3.one;
        transform.DOScale(1.2f, 2f);
        text.text = index;
        text.DOFade(1, 0f);
        yield return new WaitForSeconds(1f);
        text.DOFade(0, 1f);
        yield return new WaitForSeconds(1f);
    }
}