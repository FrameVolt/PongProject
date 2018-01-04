using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BlockerControl : MonoBehaviour {

    private int blockAmount;
    public int BlockAmount {
        get { return blockAmount; }
        set {
            blockAmount = value;
            if (blockAmount <= 0) {
                WinThisRound();
            }
        }
    }
	private void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
                blockAmount++;
        }
       
    }
	
	private void WinThisRound () {
        print("win");
        GameManager.Instance.GameWin();
	}
}
