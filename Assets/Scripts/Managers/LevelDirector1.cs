using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDirector1 : LevelDirector
{
    [SerializeField]
    private Vector3 DownRackotPos;
    public override void Decorate()
    {
        InputManager inputManager = InputManager.Instance;
        GameManager.Instance.Racket = Instantiate(racketPerfab, DownRackotPos, Quaternion.identity);
        inputManager.RacketDown = GameManager.Instance.Racket;
    }
}
