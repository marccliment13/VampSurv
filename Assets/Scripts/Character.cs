using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public Sprite sprite;
    public string characterName;
    public float walkSpeed;
    public float maxHealth;

}
