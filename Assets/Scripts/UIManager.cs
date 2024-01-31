using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject mainMenu;
    [SerializeField] List<GameObject> subMenus;


    void Start()
    {
        ResetToTitle();
    }

    public void OpenSubMenu()
    {
        foreach (GameObject menu in subMenus)
        {
            menu.SetActive(false);
        }
        title.SetActive(false);
        mainMenu.SetActive(false);
        subMenus[0].SetActive(true);
    }

    public void OpenSubMenu(int listPos)
    {
        foreach (GameObject menu in subMenus)
        {
            menu.SetActive(false);
        }
        title.SetActive(false);
        mainMenu.SetActive(false);
        subMenus[listPos].SetActive(true);
    }

    public void ResetToMainMenu()
    {
        foreach (GameObject menu in subMenus)
        {
            menu.SetActive(false);
        }
        title.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ResetToTitle()
    {
        foreach (GameObject menu in subMenus)
        {
            menu.SetActive(false);
        }
        mainMenu.SetActive(false);
        title.SetActive(true);
    }
}