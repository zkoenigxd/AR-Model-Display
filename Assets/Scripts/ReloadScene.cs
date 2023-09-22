using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
