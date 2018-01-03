using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private Transform racketTrans;
    [SerializeField]
    private LevelDirector currentDirector;
    public LevelDirector CurrentDirector { get { return currentDirector; } }
    public Transform RacketTrans { get { return racketTrans; } }

    private int score;
    public int Score {
        get { return score; }
        set { score = value; }
    }
	public int Life {
        get { return life; }
        set {
            life = value;
            if (life <= 0)
                GameOver();
        }
    }

    private UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.Instance;
    }

    public void GameOver() {

        print("GameOver!");
        uiManager.GameOver();
    }

    public void GameWin()
    {

        print("GameWin!");
        uiManager.GameWin();
    }
}
