using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    enum PlayerCount { One, Two}

    [SerializeField]
    private int life = 3;
    //private Transform racketTrans;
    //private Racket racket;
    [SerializeField]
    private LevelDirector director1;
    [SerializeField]
    private LevelDirector director2;

    private LevelDirector currentDirector;
    [SerializeField]
    private PlayerCount currentPlayerCount;


    public LevelDirector CurrentDirector { get { return currentDirector; } }
    //public Transform RacketTrans {
    //    get { return racketTrans; }
    //    set { racketTrans = value; }
    //}
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

        StartGame();
    }


    public void StartGame() {
        if (currentPlayerCount == PlayerCount.One)
            currentDirector = director1;
        else
            currentDirector = director2;

        currentDirector.Decorate();
        EventService.Instance.GetEvent<GameStartEvent>().Publish();
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
