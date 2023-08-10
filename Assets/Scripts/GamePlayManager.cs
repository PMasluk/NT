using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : Singleton<GamePlayManager>
{
    [SerializeField]
    private GameObject restartCanvas;

    private List<GameObject> objectsOnMap = new();

    public void AddObject(GameObject obj)
    {
        objectsOnMap.Add(obj);
    }

    public void TryRemoveObject(GameObject obj)
    {
        if (!objectsOnMap.Contains(obj))
        {
            return;
        }
        objectsOnMap.Remove(obj);

        if (objectsOnMap.Count <= 1)
        {
            restartCanvas.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
