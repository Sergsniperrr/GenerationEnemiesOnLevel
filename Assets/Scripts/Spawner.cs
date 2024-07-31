using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _direction;

    public void SpawnEnemy(Enemy enemyPrefab)
    {
        Enemy enemy = Instantiate(enemyPrefab);

        enemy.transform.position = transform.position;
        enemy.transform.forward = _direction.position.normalized;
    }
}
