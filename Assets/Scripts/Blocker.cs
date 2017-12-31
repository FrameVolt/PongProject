using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour, ICanTakeDamage
{
    [SerializeField]
    private int InitialHealth = 1;
    [SerializeField]
    private Color finalColor;
    private SpriteRenderer rend;
    private int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
        protected set { currentHealth = value; }
    }
    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    private void Start () {
        CurrentHealth = InitialHealth;
    }
	
    private IEnumerator DestroySelf()
    {
        GameManager.Instance.Score += 1;
        rend.enabled = false;
        yield return null;
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage, GameObject instigator)
    {
        CurrentHealth -= damage;
        rend.color = finalColor;
        if (CurrentHealth <= 0)
        {
            StartCoroutine(DestroySelf());
            return;
        }
    }
}
