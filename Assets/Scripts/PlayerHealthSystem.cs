using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : HealthSystem
{
    [SerializeField] protected Slider healthBar;

    void Start()
    {
        base.Start();
        UpdateHealthBar();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        UpdateHealthBar();
    }


    // Update is called once per frame
    void Update()
    {

    }
    void UpdateHealthBar()
    {
        healthBar.value = actualHealth / 100;
    }
}
