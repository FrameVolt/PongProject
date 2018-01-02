using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReward : MonoBehaviour {

    [SerializeField]
    private Vector3 rotateVector3;

    private void Start () {
		
	}
	
	
	private void Update () {
        transform.Rotate(rotateVector3 * Time.deltaTime);
    }
}
