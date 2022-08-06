using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{

    public GameObject[] windows;

  

    public void SelectWindow(GameObject selectedWindow)
    {
        foreach(GameObject window in windows)
        {
            window.gameObject.SetActive(false);
        }
        selectedWindow.gameObject.SetActive(true);
    }
}
