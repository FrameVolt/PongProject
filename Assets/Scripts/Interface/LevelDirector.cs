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

    private Racket initRacket;
    public Racket InitRacket { get { return initRacket; } }

    public DotLine DotLine { get { return dotLine; } }
    private void Start () {
		
	}


    public abstract void Decorate();
}
