using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private Transform targetPosition2;
    [SerializeField] private float transitionDuration = 3f; 

    private void Start()
    {
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;

        StartCoroutine(TransitionToTarget());
    }

    private IEnumerator TransitionToTarget()
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            transform.position = Vector3.Lerp(startPosition.position, targetPosition.position, elapsedTime / transitionDuration);
            transform.rotation = Quaternion.Lerp(startPosition.rotation, targetPosition.rotation, elapsedTime / transitionDuration);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPosition.position;
        transform.rotation = targetPosition.rotation;

        elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            transform.position = Vector3.Lerp(targetPosition.position, targetPosition2.position, elapsedTime / transitionDuration);
            transform.rotation = Quaternion.Lerp(targetPosition.rotation, targetPosition2.rotation, elapsedTime / transitionDuration);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPosition2.position;
        transform.rotation = targetPosition2.rotation;
    }
}