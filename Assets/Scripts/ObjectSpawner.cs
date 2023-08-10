using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefab;
    [SerializeField]
    private int maxObjectsCount;
    [SerializeField]
    private Vector2 objectPoolPosition;
    [SerializeField]
    private float maxXPosition;
    [SerializeField]
    private float maxYPosition;
    [SerializeField]
    private float minDistanceBetweenObjects;
    [SerializeField]
    private List<GameObject> objects = new();
    private List<Vector2> spawnedObjectsPositions = new();

    public void CreateObjects()
    {
        for (int i = 0; i < maxObjectsCount; i++)
        {
            GameObject spawnedObject = Instantiate(objectPrefab, objectPoolPosition, Quaternion.identity, transform);
            objects.Add(spawnedObject);
            spawnedObject.SetActive(false);
        }
    }

    public void RemoveAllObjects()
    {
        foreach (GameObject obj in objects)
        {
            DestroyImmediate(obj);
        }
        objects.Clear();
    }

    public void SpawnObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            objects[i].SetActive(true);
            objects[i].transform.position = GetRandomNewPosition();
            GamePlayManager.Instance.AddObject(objects[i]);
        }
    }

    private Vector2 GetRandomNewPosition()
    {
        Vector2 randomPosition;
        void GetNewPosition()
        {
            float randomXPosition = Random.Range(-maxXPosition, maxXPosition);
            float randomYPosition = Random.Range(-maxYPosition, maxYPosition);
            randomPosition = new Vector2(randomXPosition, randomYPosition);
        }

        GetNewPosition();
        bool isPositionGood = false;

        while (!isPositionGood)
        {
            isPositionGood = true;
            foreach (Vector2 position in spawnedObjectsPositions)
            {
                if (Vector2.Distance(position, randomPosition) < minDistanceBetweenObjects)
                {
                    GetNewPosition();
                    isPositionGood = false;
                    break;
                }
            }
        }

        spawnedObjectsPositions.Add(randomPosition);
        return randomPosition;
    }

}
