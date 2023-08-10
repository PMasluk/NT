using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
}
