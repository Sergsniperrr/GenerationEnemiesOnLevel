using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _currentLifeTime;

    private readonly float _maxLifeTime = 16;
    private readonly float _speed = 4f;

    private Vector3 _direction;

    private void Start()
    {
        _currentLifeTime = _maxLifeTime;
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);
        _currentLifeTime -= Time.deltaTime;

        if (_currentLifeTime <= 0)
            Destroy(gameObject);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}