using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> explodablePartsList;

    public void ActivateParts()
    {
        foreach(GameObject part in explodablePartsList)
        {
            part.SetActive(true);
            part.GetComponent<ExplodeObject>().ExplodeGameObject();
        }
    }

    public void DeactivateParts()
    {
        foreach (GameObject part in explodablePartsList)
        {
            if (part != null)
            {
                if (part.GetComponent<ExplodeObject>())
                    part.GetComponent<ExplodeObject>().ResetSizeandPosition();
                else
                    Debug.LogWarning(part.name + " does not have an ExplodeObject script attached or the script cannot be found.");
                part.SetActive(false);
            }
            else
                Debug.LogWarning("One of your list items in your ExplodeManger does not exist (returned null). Be sure that all list items have a vaild GameObject assigned to them (did you delete an item without removing its reference from this list?).");
        }
    }
}
