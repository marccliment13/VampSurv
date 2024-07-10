
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();

        if (healthSystem != null)
        {
            if (this.gameObject.GetComponent<Enemy>() && collision.gameObject.GetComponent<Enemy>())
            {

            }
            else
            {
                healthSystem.TakeDamage(damageAmount);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();

        if (healthSystem != null)
        {
            if (this.gameObject.GetComponent<Enemy>() && collision.gameObject.GetComponent<Enemy>())
            {

            }
            else
            {
                healthSystem.TakeDamage(damageAmount);
            }
        }
    }
}
