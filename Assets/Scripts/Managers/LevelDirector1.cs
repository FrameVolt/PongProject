﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDirector1 : LevelDirector
{

    [SerializeField]
    private Vector3 DownRackotPos;
    public override void Decorate()
    {
        downRacket = Instantiate(racketPerfab, DownRackotPos, Quaternion.identity);
        initRacket = downRacket;
        Instantiate(pongPerfab, DownRackotPos + new Vector3(0, 0.3f, 0), Quaternion.identity);
    }
}
