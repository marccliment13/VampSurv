using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    //public Sprite sprite;
    public int maxLevel;
    public float baseDamage;
    public float speed;
    public float duration;
    public float coolDown;
    public float hitboxDelay;
    public int poolLimit;
    public float critMulti;
    public int pierce;
    public float knockback;
  

}
