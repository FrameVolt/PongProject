using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDirector2 : LevelDirector
{
    [SerializeField]
    private Vector3 upRackotPos, DownRackotPos;

    public override void Decorate()
    {
        InputManager inputManager = InputManager.Instance;
        GameManager.Instance.Racket = Instantiate(racketPerfab, upRackotPos, Quaternion.identity);
        inputManager.RacketUp = GameManager.Instance.Racket;
        inputManager.RacketDown = Instantiate(racketPerfab, DownRackotPos, Quaternion.identity);

    }
}
