using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Range(0f, 360f)] private float _directionOnY;

    public void SpawnEnemy(Enemy enemy)
    {
        SetPosition(enemy);
        SetDirection(enemy);

        Instantiate(enemy);
    }

    private void SetDirection(Enemy enemy)
    {
        enemy.transform.rotation = Quaternion.Euler(0f, _directionOnY, 0f);
    }

    private void SetPosition(Enemy enemy)
    {
        enemy.transform.position = transform.position;
    }
}
