using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class PingPong : MonoBehaviour
{
    public enum State { Idle, Running }
    [Serializable]
    public struct PingPongInitData
    {
        public State state;
        public Vector3 initPosition;
        public float speed;
    }
    
    [SerializeField]
    private PingPongInitData pingPongInitData;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private TrailRenderer trail;

    private Transform initRacketTrans;
    private Vector3 pointLeft, pointRight, pointUp, pointDown;
    private Vector3[] points = new Vector3[4];
    private Vector2[] rayDirection = new Vector2[4];
    private Vector3 relativeDirection;
    private Vector3 currentDirection;
    private BoxCollider2D boxColl2D;
    private Rigidbody2D rig2D;
    private PingPongInitData currentPingPongData;
    private Racket currentRacket;
    private StateMachine<State> stateMachine;

    private void Awake()
    {
        boxColl2D = GetComponent<BoxCollider2D>();
        rig2D = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        EventService.Instance.GetEvent<PlayerRunEvent>().Subscribe(Run);
    }

    private void Start()
    {
        currentPingPongData = pingPongInitData;
        initRacketTrans = GameManager.Instance.CurrentDirector.InitRacket.transform;
        currentRacket = initRacketTrans.GetComponent<Racket>();
        relativeDirection = GameManager.Instance.CurrentDirector.PongRelativePos;
    
        stateMachine = new StateMachine<State>();
        stateMachine.AddState(State.Idle, () => { trail.enabled = false; });
        stateMachine.AddState(State.Running, () => { trail.enabled = true; });
        stateMachine.CurrentState = pingPongInitData.state;
    }

    private void Update()
    {
        if (stateMachine.CurrentState == State.Idle)
        {
           
            transform.position = initRacketTrans.position + relativeDirection;
            return;
        }
        DetecteRaycasts();
    }

    public void Run() {
        stateMachine.CurrentState = State.Running;

        currentDirection = (currentRacket.RealSpeed/10 + Vector3.up).normalized;
    }

    private void FixedUpdate()
    {
        if (stateMachine.CurrentState == State.Idle)
        {
            return;
        }
        rig2D.velocity = currentDirection * currentPingPongData.speed;
    }

    private void DetecteRaycasts() {
        RaycastHit2D results = Physics2D.BoxCast(transform.position, boxColl2D.bounds.extents*2.5f, 0f, Vector2.zero, 0f, layerMask);
        if (results.collider != null)
        {
            Vector3 fixDirection = Vector3.zero;
            if (results.collider.GetComponent<Racket>())
            {
                fixDirection = results.collider.GetComponent<Racket>().RealSpeed.normalized * 0.5f;
            }

            currentDirection = (Vector3.Reflect(currentDirection, results.normal) + fixDirection).normalized;
            
            ICanTakeDamage CanTakeDamage = results.collider.GetComponent<ICanTakeDamage>();
            if (CanTakeDamage != null)
            {
                CanTakeDamage.TakeDamage(1, this.gameObject);
            }
        }
    }

    public void DestroySelf()
    {
        //GameManager.Instance.Life -= 1;
        if(transform.position.y < 0)
            DataManager.Instance.playerMomeryDataA.Life--;
        else if(GameManager.Instance.CurrentPlayerCount == GameManager.PlayerCount.Two)
            DataManager.Instance.playerMomeryDataB.Life--;
        ResetPingPongData();
        GameManager.Instance.PingPongDeadEvent();
    }

    public void ResetPingPongData()
    {
        currentPingPongData = pingPongInitData;
        transform.rotation = Quaternion.identity;
        rig2D.velocity = Vector2.zero;
        rig2D.angularVelocity = 0f;
        stateMachine.CurrentState = pingPongInitData.state;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        boxColl2D = GetComponent<BoxCollider2D>();
        Gizmos.DrawCube(transform.position, boxColl2D.bounds.extents * 2.5f);

    }
}
