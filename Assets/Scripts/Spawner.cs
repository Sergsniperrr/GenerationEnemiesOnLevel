using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _directionPoint;

    private Vector3 _direction => _directionPoint.position;

    public void SpawnEnemy(Enemy enemyPrefab)
    {
        Enemy enemy = Instantiate(enemyPrefab);

        enemy.transform.position = transform.position;
        enemy.SetDirection((_direction - transform.position).normalized);
    }
}
