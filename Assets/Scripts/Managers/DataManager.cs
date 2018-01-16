using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct PlayerMomeryData
{
    [SerializeField]
    private PlayerData playerdata;
    [SerializeField]
    private int life;
    [SerializeField]
    private int score;
    [SerializeField]
    private float pongSpeed;
    public float PongSpeed
    {
        get { return pongSpeed; }
        set { pongSpeed = value; }
    }
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            if (score > playerdata.maxScore)
            {
                playerdata.maxScore = score;
            }
        }
    }
    public int Life
    {
        get { return life; }
        set
        {
            life = value;
        }
    }

    public void Reset() {
        Life = 3;
    }
}


public class DataManager : Singleton<DataManager>
{
    
    public PlayerMomeryData playerMomeryDataA;

    public PlayerMomeryData playerMomeryDataB;
    
    private void Start()
    {
        playerMomeryDataA.Reset();
        playerMomeryDataB.Reset();
    }
}
