using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

    
    [SerializeField]
    private Rect rectUp,rectDown;

    private Touch[] touches;
	private void Start () {
		
	}
	
	private void Update () {

        foreach (Touch touch in Input.touches)
        {
            if (!rectDown.Contains(Camera.main.ScreenToWorldPoint(touch.position))) break;
            
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                print("hey");
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,1,0.5f);
        Gizmos.DrawCube(new Vector3(rectDown.x + rectDown.width/2, rectDown.y + rectDown.height/2, 0), new Vector3(rectDown.width, rectDown.height, 0));
    }
}
