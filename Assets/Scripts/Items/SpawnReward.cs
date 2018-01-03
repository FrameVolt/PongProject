using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnReward : MonoBehaviour {

    [SerializeField]
    private Vector3 rotateVector3;
    protected Collider2D myColl;
    private void Awake()
    {
        myColl = GetComponent<Collider2D>();
    }
    private void Start () {
        rotateVector3 = Random.Range(0F, 1F) > 0.5F ? rotateVector3 : rotateVector3 * -1;
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));
    }
	
	
	private void Update () {
        transform.Rotate(rotateVector3 * Time.deltaTime);
    }
}
