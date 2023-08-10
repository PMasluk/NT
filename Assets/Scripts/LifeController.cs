using System.Collections;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    private int lifesAmount;
    [SerializeField]
    private ObjectRotator objectRotator;
    [SerializeField]
    private BulletShooter bulletShooter;
    [SerializeField]
    private float secondsToWait;
    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private SpriteRenderer[] spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boxCollider.enabled = false;
        BulletPool.Instance.ReturnToPool(collision.gameObject);
        lifesAmount--;
        if (lifesAmount <= 0)
        {
            GamePlayManager.Instance.TryRemoveObject(gameObject);
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(LostLifeCoroutine());
        }
    }

    private IEnumerator LostLifeCoroutine()
    {
        objectRotator.CanRotate = false;
        bulletShooter.CanShoot = false;


        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            spriteRenderer[i].enabled = false;
        }

        yield return new WaitForSeconds(secondsToWait);

        boxCollider.enabled = true;
        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            spriteRenderer[i].enabled = true;
        }

        objectRotator.CanRotate = true;
        bulletShooter.CanShoot = true;
    }
}
