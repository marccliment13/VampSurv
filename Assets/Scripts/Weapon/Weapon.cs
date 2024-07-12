using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Properties
    protected int maxLevel;           // Max level the weapon can be upgraded to
    protected float rarity;           // Rarity weight in the pool of weapons and passive items

    protected float baseDamage;       // Damage dealt by a single projectile per hit, modified by Might stat
    protected float area;             // Base area of the weapon, modified by Area stat
    protected float speed;            // Base projectile speed, modified by Speed stat
    protected int amount;             // Amount of projectiles fired per use, modified by Amount stat
    protected float duration;         // Duration of the weapon's effect, modified by Duration stat
    protected int pierce;             // Number of enemies a single projectile can hit before being used up
    protected float cooldown;         // Time required for the weapon to be used again, modified by Cooldown stat
    protected float projectileInterval; // Time required for an additional projectile to be fired between each cooldown
    protected float hitboxDelay;      // Time before the same enemy can be hit by the same projectile again
    protected float knockback;        // Knockback dealt multiplier of the weapon
    protected int poolLimit;          // Maximum amount of projectiles that can be on screen
    protected float chance;           // Chance of a special effect happening, modified by Luck stat
    protected float critMulti;        // Damage multiplier to critical hits
    protected bool blockByWalls;      // Can the projectile be blocked by obstacles

    protected int currentLevel = 1;

    // Example method for demonstrating the functionality of the weapon (can be expanded)
    public virtual void UseWeapon()
    {

    }

    // Example method for upgrading the weapon (can be expanded)
    public virtual void UpgradeWeapon()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            LevelUp();
        }
    }

    // Virtual method for leveling up the weapon, to be overridden by derived classes
    protected virtual void LevelUp()
    {
        
    }
}
