using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffTimer : MonoBehaviour
{

    IEnumerator TurnOffAfterSeconds()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(TurnOffAfterSeconds());
    }
}
