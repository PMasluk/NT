using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : Singleton<BulletPool>
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int maxObjectsCount;
    [SerializeField]
    private Vector2 poolPosition;
    [SerializeField]
    private List<GameObject> poolObjects;

    public void CreateObjects()
    {
        for (int i = 0; i < maxObjectsCount; i++)
        {
            GameObject spawnedObject = Instantiate(bulletPrefab, poolPosition, Quaternion.identity, transform);
            poolObjects.Add(spawnedObject);
            spawnedObject.SetActive(false);
        }
    }

    public void RemoveAllObjects()
    {
        foreach (GameObject obj in poolObjects)
        {
            DestroyImmediate(obj);
        }
        poolObjects.Clear();
    }

    public GameObject GetBullet()
    {
        GameObject bullet;

        if (poolObjects.Count > 0)
        {
            bullet = poolObjects.FirstOrDefault();
            poolObjects.Remove(bullet);
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            bullet = Instantiate(bulletPrefab);
            bullet.SetActive(true);
            return bullet;
        }
    }

    public void ReturnToPool(GameObject bullet)
    {
        bullet.SetActive(true);
        bullet.transform.position = poolPosition;
        poolObjects.Add(bullet);
    }
}
