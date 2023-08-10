using System.Collections;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField]
    private float minAngleRotation;
    [SerializeField]
    private float maxAngleRotation;
    [SerializeField]
    private float minTimeToRotate;
    [SerializeField]
    private float maxTimeToRotate;

    public bool CanRotate { get; set; } = true;

    private void Start()
    {
        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => CanRotate);
            transform.Rotate(0, 0, Random.Range(minAngleRotation, maxAngleRotation));
            yield return new WaitForSeconds(Random.Range(minTimeToRotate, maxTimeToRotate));
        }
    }

}
