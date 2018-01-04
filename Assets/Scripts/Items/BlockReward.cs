using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockReward : SpawnReward
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            myColl.enabled = false;
            GameManager.Instance.CurrentDirector.DotLine.SetDotLine();
            Destroy(this.gameObject);
        }
    }
}
