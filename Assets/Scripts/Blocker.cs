using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour, ICanTakeDamage
{
    [SerializeField]
    private int InitialHealth = 1;

    public int CurrentHealth
    {
        get;
        protected set;
    }

    private void Start () {
        CurrentHealth = InitialHealth;
    }
	
    private IEnumerator DestroySelf()
    {
        GameManager.Instance.Score += 1;
        GetComponent<Renderer>().enabled = false;
        yield return null;
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage, GameObject instigator)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            StartCoroutine(DestroySelf());
            return;
        }
    }
}
