using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelDirector : MonoBehaviour {
    [SerializeField]
    private RewardSpawner rewardSpawner;
    [SerializeField]
    private DotLine dotLine;
    [SerializeField]
    protected Racket racketPerfab;
    [SerializeField]
    protected PingPong pongPerfab;


    protected Racket downRacket;
    protected Racket upRacket;
    public Racket DownRacket { get { return downRacket; } }
    public Racket UpRacket { get { return upRacket; } }

    protected Racket initRacket;
    public Racket InitRacket { get { return initRacket; } }

    public DotLine DotLine { get { return dotLine; } }
    private void Start () {
		
	}
    
    public abstract void Decorate();
}
