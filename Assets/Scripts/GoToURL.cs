using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToURL : MonoBehaviour
{
    public void LinkToURLThroughWebApp()
    {
        Application.OpenURL("https://www.hubs.com/guides/sheet-metal-fabrication/");
    }
}
