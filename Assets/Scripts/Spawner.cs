using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private GameObject[] _spawnPoints;

    private float _repeateRate = 2f;
    private int _poolCapacity = 5;
    private int _poolMaxSize = 8;
    private ObjectPool<Enemy> _pool;
    private Dictionary<GameObject, Vector3> _spawnDirection = new Dictionary<GameObject, Vector3>();

    private GameObject RandomSpawner => _spawnPoints[Random.Range(0, _spawnPoints.Length)];

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (enemy) => ActionOnGet(enemy),
            actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
            actionOnDestroy: (enemy) => Destroy(enemy),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void ActionOnGet(Enemy enemy)
    {
        SetRandomSpawnPointAndDirection(enemy);

        enemy.gameObject.SetActive(true);
    }

    private void SetRandomSpawnPointAndDirection(Enemy enemy)
    {
        GameObject spawnPoint = RandomSpawner;
        Vector3 ShiftUp = new(0f, 0.12f, 0f);

        enemy.transform.SetPositionAndRotation(spawnPoint.transform.position + ShiftUp, Quaternion.Euler(_spawnDirection[spawnPoint]));
    }

    private void Start()
    {
        AssignSpawnDirections();

        InvokeRepeating(nameof(GetEnemy), 0.0f, _repeateRate);
    }

    private void GetEnemy()
    {
        _pool.Get().Died += ReleaseEnemy;
    }

    private void ReleaseEnemy(Enemy enemy)
    {
        _pool.Release(enemy);
        enemy.Died -= ReleaseEnemy;
    }

    private void AssignSpawnDirections()
    {
        float maxAngle = 360f;

        foreach (GameObject spawn in _spawnPoints)
            _spawnDirection.Add(spawn, new Vector3(0f, Random.Range(0, maxAngle), 0));
    }
}
