using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class DotLine : MonoBehaviour {

    [SerializeField]
    private Sprite sprite1, sprite2;

    private SpriteRenderer _renderer;
    private BoxCollider2D boxColl2D;
    private IEnumerator setDotLineYield;

    private void Awake () {
        _renderer = GetComponent<SpriteRenderer>();
        boxColl2D = GetComponent<BoxCollider2D>();
    }
	
	private void DoSetDotLine (bool isDotLine) {
        _renderer.sprite = isDotLine ? sprite1 : sprite2;
        boxColl2D.enabled = isDotLine ? false : true;
    }

    public void SetDotLine() {
        if(setDotLineYield != null)
        StopCoroutine(SetDotLineYield());

        setDotLineYield = SetDotLineYield();
        StartCoroutine(setDotLineYield);
    }

    private IEnumerator SetDotLineYield() {
        DoSetDotLine(false);
        yield return new WaitForSeconds(5);
        DoSetDotLine(true);
    }
}
