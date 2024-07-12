using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : Weapon
{
    public Transform player; // Reference to the player's transform
    private List<GameObject> spikes = new List<GameObject>(); // List to store spike instances

    private void Start()
    {      

        maxLevel = 8;
        rarity = 80;

        baseDamage = 10;
        area = 1;
        speed = 1;
        amount = 1;
        duration = 3;
        pierce = 0;
        cooldown = 3;
        projectileInterval = 0;
        hitboxDelay = 1.7f;
        knockback = 1;
        poolLimit = 50;
        blockByWalls = false;

      
    }

    // Coroutine to spawn and rotate spikes around the player
    private IEnumerator SpawnSpikes()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown + duration);

            // Clear old spikes
            foreach (GameObject spike in spikes)
            {
                Destroy(spike);
            }
            spikes.Clear();

            // Spawn new spikes
            for (int i = 0; i < amount; i++)
            {
                GameObject spike = new GameObject("SpikeBall");
                spike.transform.position = player.position + (Vector3.right * area);
                spike.transform.parent = player;
                spikes.Add(spike);

                // Rotate spikes around the player
                float angle = 360f / amount * i;
                spike.transform.RotateAround(player.position, Vector3.forward, angle);
            }

            // Wait for the duration of the spikes' effect
            yield return new WaitForSeconds(duration);

            // Trigger the cooldown
            yield return new WaitForSeconds(cooldown);
        }
    }

    // Override the LevelUp method to implement specific logic for the SpikeBall weapon
    protected override void LevelUp()
    {
        switch (currentLevel)
        {
            case 2:
                amount += 1;
                break;
            case 3:
                area *= 1.25f;
                speed *= 1.3f;
                break;
            case 4:
                duration += 0.5f;
                baseDamage += 10;
                break;
            case 5:
                amount += 1;
                break;
            case 6:
                area *= 1.25f;
                speed *= 1.3f;
                break;
            case 7:
                duration += 0.5f;
                baseDamage += 10;
                break;
            case 8:
                amount += 1;
                break;
            default:
                Debug.LogWarning("SpikeBall is already at max level or an invalid level was reached.");
                break;
        }
    }

    private void Update()
    {
        // Rotate spikes around the player based on speed
        foreach (GameObject spike in spikes)
        {
            spike.transform.RotateAround(player.position, Vector3.forward, speed * Time.deltaTime);
        }
    }

   
}
