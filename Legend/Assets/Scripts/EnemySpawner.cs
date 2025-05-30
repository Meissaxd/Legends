using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 10f;
    public Transform target; 

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

        EnemyNavigation nav = enemy.GetComponent<EnemyNavigation>();
        if (nav != null)
        {
            nav.target = target; 
        }
    }
}