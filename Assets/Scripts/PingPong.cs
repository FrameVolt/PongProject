using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct PingPongInitData
{
    public Vector3 initPosition;
    public float speed;
    public bool isStarted;
}

public class PingPong : MonoBehaviour
{
    [SerializeField]
    private PingPongInitData pingPongInitData;
    [SerializeField]
    private LayerMask layerMask;
    
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

    private void Awake()
    {
        boxColl2D = GetComponent<BoxCollider2D>();
        rig2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentPingPongData = pingPongInitData;

        racketTrans = GameManager.Instance.RacketTrans;
        currentRacket = racketTrans.GetComponent<Racket>();
        relativeDirection = transform.position - racketTrans.position;

        //currentDirection = new Vector3(Random.Range(-1f, 1f), Random.value, 0).normalized;

        pointLeft = new Vector3(-boxColl2D.bounds.extents.x, 0);
        pointRight = new Vector3(boxColl2D.bounds.extents.x, 0);
        pointUp = new Vector3(0, boxColl2D.bounds.extents.y);
        pointDown = new Vector3(0, -boxColl2D.bounds.extents.y);

        points[0] = pointLeft;
        points[1] = pointRight;
        points[2] = pointUp;
        points[3] = pointDown;

        rayDirection[0] = Vector2.left;
        rayDirection[1] = Vector2.right;
        rayDirection[2] = Vector2.up;
        rayDirection[3] = Vector2.down;
    }

    private void Update()
    {
        
        if (!currentPingPongData.isStarted && Input.GetKeyDown(KeyCode.Space))
            currentPingPongData.isStarted = true;
        if (!currentPingPongData.isStarted)
        {
            currentDirection = (currentRacket.RealSpeed.normalized + Vector3.up).normalized;
            transform.position = racketTrans.position + relativeDirection;
            return;
        }
        DetecteRaycasts();
    }
    private void FixedUpdate()
    {
        if (!currentPingPongData.isStarted)
            return;
        rig2D.velocity = currentDirection * currentPingPongData.speed;


    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        ICanTakeDamage CanTakeDamage = coll.collider.GetComponent<ICanTakeDamage>();
        if (CanTakeDamage != null) {
            CanTakeDamage.TakeDamage(1, this.gameObject);
        }
    }

    private void DetecteRaycasts()
    {
        for (int i = 0; i < points.Length; i++)
        {
            RaycastHit2D results = Physics2D.Raycast(transform.position + points[i], rayDirection[i], 0.02f, layerMask);
            if (results.collider != null)
            {
                Vector3 fixDirection = Vector3.zero;
                if (results.collider.GetComponent<Racket>())
                {
                    fixDirection = results.collider.GetComponent<Racket>().RealSpeed.normalized * 0.5f;
                }
                
                currentDirection = (Vector3.Reflect(currentDirection, results.normal) + fixDirection).normalized;
                
                break;
            }
        }

        Debug.DrawLine(transform.position + pointLeft, transform.position + pointLeft + Vector3.left * 0.02f);
        Debug.DrawLine(transform.position + pointRight, transform.position + pointRight + Vector3.right * 0.02f);
        Debug.DrawLine(transform.position + pointUp, transform.position + pointUp + Vector3.up * 0.02f);
        Debug.DrawLine(transform.position + pointDown, transform.position + pointDown + Vector3.down * 0.02f);
    }

    private void DetecteRaycasts2() {

    }

    public void DestroySelf()
    {
        GameManager.Instance.Life -= 1;
        ResetPingPongData();
    }

    public void ResetPingPongData()
    {
        //transform.position = pingPongInitData.initPosition;
        currentPingPongData = pingPongInitData;
    }
}
