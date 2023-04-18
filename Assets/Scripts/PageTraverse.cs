using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PageTraverse : MonoBehaviour
{
    [SerializeField] List<GameObject> menuItems;
    [SerializeField] TMP_Text pageNumberTracker;
    [SerializeField] Material highlightMaterial;
    List<Material> originalMaterial;
    [SerializeField] List<GameObject> highlightObjects;
    public int CurrentMenuIndex { get; private set; }

    private void Awake()
    {
        originalMaterial = new();
        int i = 0;
        foreach (var item in highlightObjects)
        {
            if (item.GetComponent<MeshRenderer>() != null)
            {
                originalMaterial.Add(item.GetComponent<MeshRenderer>().material);
                ++i;
            }
        }
    }

    private void OnEnable()
    {
        CurrentMenuIndex = 0;
        foreach (GameObject go in menuItems)
        {
            go.SetActive(false);
        }
        menuItems[CurrentMenuIndex].SetActive(true);
        UpdatePageNumber();
        HighlightObjects(CurrentMenuIndex);
    }

    public void Forward()
    {
        if (menuItems.Count > CurrentMenuIndex + 1)
        {
            CurrentMenuIndex++;
            foreach (GameObject go in menuItems)
            {
                go.SetActive(false);
            }
            menuItems[CurrentMenuIndex].SetActive(true);
        }
        UpdatePageNumber();
        HighlightObjects(CurrentMenuIndex);
    }

    public void Back()
    {
        if (CurrentMenuIndex > 0)
        {
            CurrentMenuIndex--;
            foreach (GameObject go in menuItems)
            {
                go.SetActive(false);
            }
            menuItems[CurrentMenuIndex].SetActive(true);
        }
        UpdatePageNumber();
        HighlightObjects(CurrentMenuIndex);
    }

    public void GoToElement(int element)
    {
        if (menuItems.Count > element)
        {
            CurrentMenuIndex = element;
            foreach (GameObject go in menuItems)
            {
                go.SetActive(false);
            }
            menuItems[CurrentMenuIndex].SetActive(true);
        }
        else
            Debug.LogWarning("Chosen menu index is outside of the bounds of your Menu Items list.");
        UpdatePageNumber();
        HighlightObjects(CurrentMenuIndex);
    }

    void UpdatePageNumber()
    {
        if(pageNumberTracker != null)
            pageNumberTracker.text = "Page " + (CurrentMenuIndex + 1) + " of " + menuItems.Count;
    }

    public void HighlightObjects(int currentIndex)
    {
        foreach (var obj in highlightObjects)
        {
            if (obj.GetComponent<HighlightByIndex>().Index == currentIndex)
            {
                obj.GetComponent<Renderer>().material = highlightMaterial;
            }
            else
                obj.GetComponent<Renderer>().material = originalMaterial[highlightObjects.IndexOf(obj)];
        }
    }
}