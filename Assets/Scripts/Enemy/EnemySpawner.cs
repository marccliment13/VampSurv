using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyData[] enemyDataArray; // Array de ScriptableObjects de enemigos
    public Transform player; // Referencia al jugador
    public float spawnRadius = 50f; // Radio de generación de enemigos
    public float spawnInterval = 2f; // Intervalo de tiempo entre generaciones
    public int poolSize = 100; // Tamaño de la pool
    public GameObject gemPrefab; // Prefab de la gema
    private Queue<GameObject> enemyPool; // Pool de enemigos
    private Queue<GameObject> gemPool; // Pool de gemas

    private void Start()
    {
        InitializePools();
        StartCoroutine(SpawnEnemies());
    }

    private void InitializePools()
    {
        enemyPool = new Queue<GameObject>();
        gemPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            // Crear y desactivar enemigos para la pool
            GameObject enemy = Instantiate(enemyDataArray[0].enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);

            // Crear y desactivar gemas para la pool
            GameObject gem = Instantiate(gemPrefab);
            gem.SetActive(false);
            gemPool.Enqueue(gem);
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (enemyPool.Count > 0)
        {
            GameObject instantiatedEnemy = enemyPool.Dequeue();
            EnemyData enemyData = enemyDataArray[Random.Range(0, enemyDataArray.Length)];

            float randomAngle = Random.Range(0f, 2 * Mathf.PI);

            // Calcular el vector de desplazamiento usando el ángulo aleatorio
            float offsetX = Mathf.Cos(randomAngle) * spawnRadius;
            float offsetY = Mathf.Sin(randomAngle) * spawnRadius;

            instantiatedEnemy.transform.position = new Vector3(player.position.x + offsetX, player.position.y + offsetY, player.position.z);
            instantiatedEnemy.SetActive(true);

            Enemy enemyScript = instantiatedEnemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.Initialize(enemyData, player);
            }
        }
    }

    public void OnEnemyDeath(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
        SpawnGem(enemy.transform.position);
    }

    void SpawnGem(Vector3 position)
    {
        if (gemPool.Count > 0)
        {
            GameObject gem = gemPool.Dequeue();
            gem.transform.position = position;
            gem.SetActive(true);

            // Opcional: Devolver la gema a la pool después de un tiempo
            StartCoroutine(ReturnGemToPool(gem, 5f));
        }
    }

    IEnumerator ReturnGemToPool(GameObject gem, float delay)
    {
        yield return new WaitForSeconds(delay);
        gem.SetActive(false);
        gemPool.Enqueue(gem);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, spawnRadius);
    }
}
