using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    private void OnMouseDown()
    {
        QuitGame();
    }

    void QuitGame()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;

#else

        Application.Quit();
#endif
    }

}
