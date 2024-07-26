using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Enemy : MonoBehaviour
{
    private readonly float _maxLifeTime = 16;
    private readonly float _delay = 1f;
    private readonly float _speed = 4f;

    [SerializeField] private float _currentLifeTime;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        _currentLifeTime -= Time.deltaTime * _delay;

        if (_currentLifeTime <= 0)
            Destroy(gameObject);
    }

    private void Start()
    {
        _currentLifeTime = _maxLifeTime;
    }
}