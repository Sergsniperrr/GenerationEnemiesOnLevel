using System.Collections;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    private readonly float _delay = 2f;

    [SerializeField] private Enemy _prefab;
    [SerializeField] private Spawner[] _spawners;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void SpawnOnRandomSpawner()
    {
        int spawnerNumber = Random.Range(0, _spawners.Length);

        _spawners[spawnerNumber].SpawnEnemy(_prefab);
    }

    private IEnumerator Spawn()
    {
        bool isMoving = true;

        while (isMoving)
        {
            SpawnOnRandomSpawner();

            yield return _wait;
        }
    }
}
