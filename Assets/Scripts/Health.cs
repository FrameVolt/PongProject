using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour, ICanTakeDamage
{

    [SerializeField]
    private int InitialHealth = 1;
    
    [SerializeField]
    private UnityEvent destroyEvent;
    public UnityEvent DestroyEvent { set { destroyEvent = value; } }
    public int CurrentHealth
    {
        get;
        protected set;
    }

    public void TakeDamage(int damage, GameObject instigator)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            DestroySelf();
            return;
        }
    }

    private void Start () {
        CurrentHealth = InitialHealth;
    }
	
	
	private void DestroySelf() {
        if (destroyEvent != null)
            destroyEvent.Invoke();
        else
            Destroy(this.gameObject);
	}
}
