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
        Vector3 pongPos;
        if (Random.value > 0.5f) {
            PongRelativePos = new Vector3(0, 0.3f, 0);
            pongPos = DownRackotPos + PongRelativePos;
            initRacket = downRacket;
        } else {
            PongRelativePos = -new Vector3(0, 0.3f, 0);
            pongPos = upRackotPos + PongRelativePos;
            initRacket = upRacket;
        }
        
        Instantiate(pongPerfab, pongPos, Quaternion.identity);
    }
}
