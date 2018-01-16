using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public enum PlayerCount { One, Two }

    //[SerializeField]
    //private int life = 3;
    [SerializeField]
    private LevelDirector director1;
    [SerializeField]
    private LevelDirector director2;

    private LevelDirector currentDirector;
    [SerializeField]
    private PlayerCount currentPlayerCount;

    public PlayerCount CurrentPlayerCount { get { return currentPlayerCount; } }

    public LevelDirector CurrentDirector { get { return currentDirector; } }

    //private int score;
    //public int Score
    //{
    //    get { return score; }
    //    set { score = value; }
    //}
    //public int Life
    //{
    //    get { return life; }
    //    set
    //    {
    //        life = value;
    //        if (life <= 0)
    //            GameOver();
    //    }
    //}

    private bool gameActived;

    public bool GameActived
    {
        get { return gameActived; }
        private set { gameActived = value; }
    }

    private bool playerActived;

    public bool PlayerActived
    {
        get { return playerActived; }
        private set { playerActived = value; }
    }

    private UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.Instance;
    }
    private void ActiveGame()
    {
        gameActived = true;
        PlayerActived = true;
        if (currentPlayerCount == PlayerCount.One)
            currentDirector = director1;
        else
            currentDirector = director2;
        currentDirector.Decorate();

        PlayerCtrlActiveEvent();
    }

    public void GameOver()
    {
        uiManager.GameOver();
    }

    public void GameWin()
    {
        uiManager.GameWin();
    }
    public void GameActiveEvent()
    {
        EventService.Instance.GetEvent<GameActiveEvent>().Publish();
        ActiveGame();
    }
    
    private void PlayerCtrlActiveEvent()
    {
        EventService.Instance.GetEvent<PlayerCtrlActiveEvent>().Publish();
    }
    public void PlayerRunEvent()
    {
        EventService.Instance.GetEvent<PlayerRunEvent>().Publish();
    }
    public void PingPongDeadEvent()
    {
        PlayerActived = false;
        EventService.Instance.GetEvent<PingPongDeadEvent>().Publish();
    }
    public void PlayerReGoEvent()
    {
        PlayerActived = true;
        EventService.Instance.GetEvent<PlayerRegoEvent>().Publish();
    }
}
