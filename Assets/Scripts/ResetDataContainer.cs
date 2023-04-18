using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDataContainer : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 localScale;
    Quaternion localRotation;

    void Awake()
    {
        startPosition = transform.localPosition;
        localScale = transform.localScale;
        localRotation = transform.localRotation;
    }

    private void OnEnable()
    {
        ResetSolver();
        ResetPositionRotationScale();
    }

    public void ResetAllActive()
    {
        ResetDataContainer[] resetableObjects = FindObjectsOfType<ResetDataContainer>();
        foreach (ResetDataContainer rObject in resetableObjects)
        {
            rObject.ResetPositionRotationScale();
            rObject.ResetSolver();
        }
    }

    public Vector3 GetStartPosition() { return startPosition; }

    public Vector3 GetLocalScale() { return localScale; }

    public void ResetSolver()
    {
        if(GetComponent<RadialView>())
            GetComponent<RadialView>().enabled = false;
    }

    public void ResetPositionRotationScale()
    {
        transform.localPosition = startPosition;
        transform.localScale = localScale;
        transform.localRotation = localRotation;
    }
}
