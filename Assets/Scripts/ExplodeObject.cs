using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExplodeObject : MonoBehaviour
{
    // PUBLIC
    // This public variable should be turned on durning runtime to adjust the "endPosition" while in playmode
    public bool positionAdjustmentMode;
    // Note: Adjusments made in playmode must be re-entered after exiting playmode
    // Note: Alternitively, you can right-click "copy" the "ExplodeObject" component and paste it after exiting playmode (this will only work for one item at a time)


    // PRIVATE
    Vector3 startPosition;
    Vector3 startSize;
    bool exploding;

    // PRIVATE && EXPOSED TO EDITOR
    [SerializeField] Vector3 endPosition;
    [SerializeField] float moveSpeed;

    // Caches the objects values on load. These are leveraged by the reset function.
    void Awake()
    {
        startPosition = transform.localPosition;
        startSize = transform.localScale;
    }

    // When oject is active, this checks to see if it has reached its exploded position. If it hasn't, it moves it in that direction until it is very close to the destination.
    private void Update()
    {
        if (exploding)
        {
            transform.localPosition += moveSpeed * Time.deltaTime * (endPosition - transform.localPosition).normalized;
            if (transform.localPosition.magnitude - endPosition.magnitude > .00000001f)
                exploding = positionAdjustmentMode;
        }

    }

    public void ExplodeGameObject()
    {
        exploding = true;
    }

    // Resets the object's size and scale based on its editor values when the experience first loads
    public void ResetSizeandPosition()
    {
        exploding = false;
        transform.localPosition = startPosition;
        transform.localScale = startSize;
    }
}
