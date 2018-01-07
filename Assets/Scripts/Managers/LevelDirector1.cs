using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDirector1 : LevelDirector
{

    [SerializeField]
    private Vector3 DownRackotPos;
    public override void Decorate()
    {
        downRacket = Instantiate(racketPerfab, DownRackotPos, Quaternion.identity);
    }
}
