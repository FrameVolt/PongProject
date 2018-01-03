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

    private Transform racketTrans;
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
    }

    private void Start()
    {
        currentPingPongData = pingPongInitData;
        racketTrans = GameManager.Instance.RacketTrans;
        currentRacket = racketTrans.GetComponent<Racket>();
        relativeDirection = transform.position - racketTrans.position;
    
        stateMachine = new StateMachine<State>();
        stateMachine.AddState(State.Idle, () => { trail.enabled = false; });
        stateMachine.AddState(State.Running, () => { trail.enabled = true; });
        stateMachine.CurrentState = pingPongInitData.state;
    }

    private void Update()
    {
        if (stateMachine.CurrentState == State.Idle && Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.CurrentState = State.Running;
        }
        if (stateMachine.CurrentState == State.Idle)
        {
            currentDirection = (currentRacket.RealSpeed.normalized + Vector3.up).normalized;
            transform.position = racketTrans.position + relativeDirection;
            return;
        }
        DetecteRaycasts2();
    }
    private void FixedUpdate()
    {
        if (stateMachine.CurrentState == State.Idle)
            return;
        rig2D.velocity = currentDirection * currentPingPongData.speed;
    }

    private void DetecteRaycasts2() {
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
        GameManager.Instance.Life -= 1;
        ResetPingPongData();
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
