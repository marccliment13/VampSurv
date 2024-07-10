using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : HealthSystem
{
    [SerializeField] GameObject gem;
  
    public override void Die()
    {
        actualHealth = 0;
        isAlive = false;
        Instantiate(gem, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
