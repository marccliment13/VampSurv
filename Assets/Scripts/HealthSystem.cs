
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float actualHealth;
    public bool isAlive;

    protected void Start()
    {
        isAlive = true;       
        actualHealth = maxHealth;
    }
    public virtual void TakeDamage(float damage)
    {
        actualHealth -= damage;
      
        if (actualHealth <= 0)
        {            
            Die();
        }        
    }
    public virtual void Die()
    {
        actualHealth = 0;
        isAlive = false;
        Destroy(gameObject);
    }
}
