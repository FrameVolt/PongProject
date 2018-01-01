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
    private BlockerControl blockControl;

    private float damageFrequency = 0.5f;

    public int CurrentHealth
    {
        get { return currentHealth; }
        protected set { currentHealth = value; }
    }
    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        blockControl = GetComponentInParent<BlockerControl>();
    }
    private void Start () {
        CurrentHealth = InitialHealth;
    }

    private void Update()
    {
        damageFrequency += Time.deltaTime;
    }

    private IEnumerator DestroySelf()
    {
        GameManager.Instance.Score += 1;
        rend.enabled = false;
        yield return null;
        Destroy(this.gameObject);
        blockControl.BlockAmount--;
    }

    //private void DestroySelf()
    //{
    //    GameManager.Instance.Score += 1;
    //    Destroy(this.gameObject);
    //}

    public void TakeDamage(int damage, GameObject instigator)
    {
        if (damageFrequency < 0.5f) return;
        CurrentHealth -= damage;
        damageFrequency = 0f;
        rend.color = finalColor;
        if (CurrentHealth <= 0)
        {
            StartCoroutine(DestroySelf());
            //DestroySelf();
            return;
        }
    }
}
