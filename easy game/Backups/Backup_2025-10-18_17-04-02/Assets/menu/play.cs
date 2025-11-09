using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    [SerializeField] private string battlefield;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(battlefield);
    }
    
}
