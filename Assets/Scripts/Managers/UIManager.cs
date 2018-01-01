using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager> {
    [SerializeField]
    private GameObject gameOverPannel;
    [SerializeField]
    private GameObject gameWinPannel;

	private void Start () {
		
	}
	
	
	public void GameWin () {
        gameWinPannel.SetActive(true);

    }

    public void GameOver()
    {
        gameOverPannel.SetActive(false);
    }
}
