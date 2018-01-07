using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDirector2 : LevelDirector
{
    [SerializeField]
    private Vector3 upRackotPos, DownRackotPos;

    public override void Decorate()
    {
        upRacket = Instantiate(racketPerfab, upRackotPos, Quaternion.identity);
        downRacket = Instantiate(racketPerfab, DownRackotPos, Quaternion.identity);
    }
}
