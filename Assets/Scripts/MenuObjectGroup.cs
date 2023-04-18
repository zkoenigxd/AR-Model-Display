using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObjectGroup : MonoBehaviour
{
    [SerializeField] List<GameObject> groupedObjects;

    private void Awake()
    {
        foreach (GameObject go in groupedObjects)
        {
            go.SetActive(false);
        }
    }

    private void OnEnable()
    {
        foreach (GameObject go in groupedObjects)
        {
            go.SetActive(true);
        }
    }

    private void OnDisable()
    {
        foreach(GameObject go in groupedObjects)
        {
            go.SetActive(false);
        }
    }
}
