using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Spawner[] _spawners;

    private float _repeateRate = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnOnRandomSpawner), 0.0f, _repeateRate);
    }

    private void SpawnOnRandomSpawner()
    {
        _spawners[Random.Range(0, _spawners.Length)].SpawnEnemy(_prefab);
    }
}
