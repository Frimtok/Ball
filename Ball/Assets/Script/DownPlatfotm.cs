using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DownPlatfotm : MonoBehaviour
{
    public delegate void Damage(int damage);
    public static event Damage OnDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            Destroy(ball.gameObject);
            OnDamage?.Invoke(ball.Damage);
        }
    }

}
