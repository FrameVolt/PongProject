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

	private void Awake () {
        _renderer = GetComponent<SpriteRenderer>();
        boxColl2D = GetComponent<BoxCollider2D>();
    }
	
	private void SetDotLine (bool isDotLine) {
        _renderer.sprite = isDotLine ? sprite1 : sprite2;
        boxColl2D.enabled = isDotLine ? false : true;
    }

    public IEnumerator SetDotLine() {
        SetDotLine(false);

        yield return new WaitForSeconds(5);
        SetDotLine(true);
    }
}
