using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitfunction : MonoBehaviour
{
    public void ExitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
