using UnityEngine;

public class AreaCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletPool.Instance.ReturnToPool(collision.gameObject);
    }
}
