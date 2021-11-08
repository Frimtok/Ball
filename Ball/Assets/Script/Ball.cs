using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Ball : MonoBehaviour, IPointerClickHandler
{
    public int Damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _score;
    public delegate void Score(int score);
    public static event Score OnAddScore;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Color _color;
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.timeScale != 0)
        {
            Burst();
        }
    }
    public void Boost(float boost)
    {
        _speed += boost;
    }
    private void FixedUpdate()  
    {
        Move(_speed);
    }
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        _spriteRenderer.color = _color;
    }
    private void Burst()
    {
        _speed = 0;
        OnAddScore?.Invoke(_score);
        if (_particleSystem != null)
        {
            var main = _particleSystem.main;
            main.startColor = _color;
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    private void Move(float speed)
    {
        _transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
    }
}
