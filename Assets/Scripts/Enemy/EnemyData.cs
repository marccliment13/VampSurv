using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public float speed; // Velocidad del enemigo
    public int health; // Salud del enemigo
}
