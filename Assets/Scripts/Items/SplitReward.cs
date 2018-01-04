using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitReward : SpawnReward
{
   
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            myColl.enabled = false;
            Destroy(this.gameObject);
            print("SplitReward");
        }
    }
}
