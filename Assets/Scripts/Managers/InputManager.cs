﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

    
    [SerializeField]
    private Rect rectUp,rectDown;
    private Racket racketUp;
    private Racket racketDown;
    public Racket RacketUp { get { return racketUp; } set { racketUp = value; } }
    public Racket RacketDown { get { return racketDown; } set { racketDown = value; } }

    private int upRectTouchCount;
    private int downRectTouchCount;

    private float lastX;

    protected override void Awake()
    {
        base.Awake();
        EventService.Instance.GetEvent<PlayerCtrlActiveEvent>().Subscribe(PlayerCtrlActive);
    }
    private void PlayerCtrlActive() {
        racketUp = GameManager.Instance.CurrentDirector.UpRacket;
        racketDown = GameManager.Instance.CurrentDirector.DownRacket;
    }

	private void Update () {
        if (AppConst.platform == AppConst.Platform.Android)
        {
            foreach (Touch touch in Input.touches)
            {
                if (!GameManager.Instance.GameActived && touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
                    GameManager.Instance.GameActiveEvent();
                }
                if (GameManager.Instance.GameActived && !GameManager.Instance.PlayerActived && touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
                    GameManager.Instance.PlayerReGoEvent();
                }


                if (racketUp && rectUp.Contains(Camera.main.ScreenToWorldPoint(touch.position)))
                {
                    if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                    {
                        racketUp.Follow(Camera.main.ScreenToWorldPoint(touch.position));
                    }
                }
                else if (racketDown && rectDown.Contains(Camera.main.ScreenToWorldPoint(touch.position)))
                {
                    if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                    {
                        racketDown.Follow(Camera.main.ScreenToWorldPoint(touch.position));
                    }
                }
            }
        }else if(AppConst.platform == AppConst.Platform.Editor)
        {
            
            if (!GameManager.Instance.GameActived && Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.GameActiveEvent();
            }
            if (GameManager.Instance.GameActived && !GameManager.Instance.PlayerActived && Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.PlayerReGoEvent();
            }


            if (racketUp && rectUp.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (Input.GetMouseButton(0))
                {
                    racketUp.Follow(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }
            else if (racketDown && rectDown.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (Input.GetMouseButton(0))
                {
                    racketDown.Follow(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,1,0.5f);
        Gizmos.DrawCube(new Vector3(rectDown.x + rectDown.width/2, rectDown.y + rectDown.height/2, 0), new Vector3(rectDown.width, rectDown.height, 0));
        Gizmos.DrawCube(new Vector3(rectUp.x + rectUp.width / 2, rectUp.y + rectUp.height / 2, 0), new Vector3(rectUp.width, rectUp.height, 0));
    }
}
