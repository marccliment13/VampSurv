using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Transform player;
    protected float speed;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    [SerializeField] private GameObject gem;

    public void Initialize(EnemyData data, Transform playerTransform)
    {
        speed = data.speed;  
        player = playerTransform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        FollowPlayer();
        DropGem();
    }

    protected void FollowPlayer()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * speed;

        // Flip the enemy to face the player
        Flip(direction.x);
    }

    protected void Flip(float directionX)
    {
        if (directionX > 0)
        {
            spriteRenderer.flipX = false; // Ensure the enemy faces right
        }
        else if (directionX < 0)
        {
            spriteRenderer.flipX = true; // Ensure the enemy faces left
        }
    }

 
    void DropGem()
    {
        if (!GetComponent<HealthSystem>().isAlive) {
            Instantiate(gem);        
        }
    }
 

}
