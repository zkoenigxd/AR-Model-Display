using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    bool[] contentViewed;
    [SerializeField] int numContentToView;
    [SerializeField] List<MeshRenderer> completionRenderers;
    [SerializeField] Material material;
    [SerializeField] GameObject resetButton;

    private void Start()
    {
        resetButton.SetActive(false);
        contentViewed = new bool[numContentToView];
    }

    public void MarkAsViewed(int index)
    {
        contentViewed[index] = true;
        if (CheckIfAllViewed()) { 
            foreach (var cRenderer in completionRenderers)
            {
                cRenderer.material = material;
            }
            resetButton.SetActive(true);
        }
    }

    bool CheckIfAllViewed()
    {
        foreach (bool viewed in contentViewed)
        {
            if (!viewed)
                return false;
        }
        return true;
    }
}
