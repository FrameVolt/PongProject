using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSpawner : MonoBehaviour {
    
    [SerializeField]
    private float repeatRate = 5f;
    [SerializeField]
    private SpawnReward[] spawnReward;

    private void Start() {
        EventService.Instance.GetEvent<PlayerRunEvent>().Subscribe(StartSpawn);
        EventService.Instance.GetEvent<PlayerDeadEvent>().Subscribe(CancelSpawn);
    }
    private void StartSpawn() {
        InvokeRepeating("Spawn", 0f, repeatRate);
    }
    private void CancelSpawn() {
        CancelInvoke("Spawn");
    }
	
	private void Spawn () {
        int index = Random.Range(0, spawnReward.Length);
        if(spawnReward.Length > 0)
        Instantiate(spawnReward[index], new Vector2(Random.Range(-2f, 2f), Random.Range(-1f, 3f)), Quaternion.identity);
    }
}
