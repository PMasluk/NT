using System.Collections;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField]
    private Transform startBulletTransform;
    [SerializeField]
    private float timeBetweenShoots;

    public bool CanShoot { get; set; } = true;

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => CanShoot);
            yield return new WaitForSeconds(timeBetweenShoots);
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = startBulletTransform.position;
        bullet.transform.rotation = startBulletTransform.rotation;
    }
}
