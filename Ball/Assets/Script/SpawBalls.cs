using System.Collections;
using UnityEngine;

public class SpawBalls : MonoBehaviour
{
    [SerializeField]private Ball[] _balls;
    [SerializeField]private float _waitSpawn;
    [SerializeField]private float _minX, _maxX;
    [SerializeField]private float _positionY;
    [SerializeField]private float _period;
    [SerializeField]private float _incrimentBoost;
    [SerializeField] private float _maxBoost;
    private Ball _ball;
    private float _boostSpeed;
    private void Start()
    {
        StartCoroutine(WaitSpawn());
        StartCoroutine(WaitBoost());
    }
    private void Spaw()
    {
        float randomX = Random.Range(_minX, _maxX);
        foreach (var ball in _balls)
        {
            var spawnPoint = new Vector2(Random.Range(_minX, _maxX), _positionY);
            _ball =  Instantiate(ball, spawnPoint, Quaternion.identity);
            _ball.Boost(_boostSpeed);
        }
    }
    private IEnumerator WaitSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_waitSpawn);
            Spaw();
        }
    }
    private IEnumerator WaitBoost()
    {
        while (_boostSpeed < _maxBoost)
        {
            yield return new WaitForSeconds(_period);
            _boostSpeed += _incrimentBoost;
        }

    }
}
