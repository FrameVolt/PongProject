using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

    public int count;

    private Touch[] touches;
	private void Start () {
		
	}
	
	
	private void Update () {
        count = Input.touchCount;

        //touches = Input.touches;
        //foreach (var item in touches)
        //{
        //    item.
        //}
	}
}
