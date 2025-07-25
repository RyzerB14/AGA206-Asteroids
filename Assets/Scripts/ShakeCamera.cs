using UnityEngine;
using System.Collections;


public class ShakeCamera : MonoBehaviour
{
    public float duration = 1f;
    public bool Start = false;
    public AnimationCurve Curve;
    private void Update()
    {
        if (Start)
        {
            Start = false;
            StartCoroutine(ShakeRoutine());
        }
    }

    public IEnumerator ShakeRoutine()
    {
        Vector3 originalPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = originalPos + Random.insideUnitSphere;
            yield return null;
        }

        transform.position = originalPos;


    }
}

