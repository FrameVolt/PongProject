using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class CountDownPannel : MonoBehaviour {

    private Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
    }
    private void Start()
    {
        StartCoroutine(StartCount());
    }

    private IEnumerator StartCount () {
        text.enabled = true;
        yield return StartCoroutine(Fade(3));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(Fade(2));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(Fade(1));
        yield return new WaitForSeconds(1f);
        text.enabled = false;

    }

    private IEnumerator Fade(int index) {
        transform.localScale = Vector3.one;
        transform.DOScale(1.2f, 2f);
        text.text = index.ToString();
        text.DOFade(1, 0f);
        yield return new WaitForSeconds(1f);
        text.DOFade(0, 1f);
    }
}
