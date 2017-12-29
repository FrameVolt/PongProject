using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {
    [SerializeField]
    private float speed;


    public Vector3 RealSpeed { get; private set; }

    private Vector3 pointLeft;
    private Vector3 pointRight;
    private float directionX;
    private BoxCollider2D boxColl2D;
    private Vector3 lastPosition;

    private void Awake () {
        boxColl2D = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        pointLeft = new Vector3(-boxColl2D.bounds.extents.x - 0.01f, 0);
        pointRight = new Vector3(boxColl2D.bounds.extents.x + 0.01f, 0);
        lastPosition = transform.position;
    }

    private void Update()
    {

        RaycastHit2D resultsLeft = Physics2D.Raycast(transform.position + pointLeft, Vector2.left, 0.01f);
        RaycastHit2D resultsRight = Physics2D.Raycast(transform.position + pointRight, Vector2.right, 0.01f);
        directionX = Input.GetAxisRaw("Horizontal");

        if (resultsLeft.collider == null && directionX < 0)
        {
            this.transform.position += new Vector3(directionX * Time.deltaTime * speed, 0, 0);
        }
        else if (resultsRight.collider == null && directionX > 0)
        {
            this.transform.position += new Vector3(directionX * Time.deltaTime * speed, 0, 0);
        }

        Debug.DrawLine(transform.position + pointLeft, transform.position + pointLeft + Vector3.left * 0.01f);
        Debug.DrawLine(transform.position + pointRight, transform.position + pointRight + Vector3.right * 0.01f);



        RealSpeed = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }

}
