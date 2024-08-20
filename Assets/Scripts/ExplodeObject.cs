using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;

public class ExplodeObject : MonoBehaviour
{
    // PRIVATE
    Vector3 startPosition;
    Vector3 startSize;

    // PRIVATE && EXPOSED TO EDITOR
    [SerializeField] Vector3 endPosition;
    [SerializeField] float lerpDuration;

    // Caches the objects values on load. These are leveraged by the reset function.
    void Awake()
    {
        startPosition = transform.localPosition;
        startSize = transform.localScale;
    }

    public void ExplodeGameObject()
    {
        StartCoroutine(LerpPosition(endPosition, lerpDuration));
        StartCoroutine(LerpScale(startSize, lerpDuration));
    }

    public void AssembleGameObject()
    {
        StartCoroutine(LerpPosition(startPosition, lerpDuration));
        StartCoroutine(LerpScale(startSize, lerpDuration));
    }

    // Resets the object's size and scale based on its editor values when the experience first loads
    public void ResetSizeandPosition()
    {
        transform.localPosition = startPosition;
        transform.localScale = startSize;
        //ManipulatorState(false);
    }

    IEnumerator LerpScale(Vector3 targetScale, float duration)
    {
        float time = 0;
        Vector3 startScale = transform.localScale;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;
        Debug.Log("Scale complete");
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.localPosition;

        while (time < duration)
        {
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetPosition;
        Debug.Log("Move complete");
        ManipulatorState(true);
    }

    private void ManipulatorState(bool state)
    {
        if (gameObject.GetComponent<ObjectManipulator>() != null)
        {
            gameObject.GetComponent<ObjectManipulator>().enabled = state;
        }
        if (gameObject.GetComponent<NearInteractionGrabbable>() != null)
        {
            gameObject.GetComponent<NearInteractionGrabbable>().enabled = state;
        }
    }
}
