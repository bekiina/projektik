using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int hearts = 3;

    void Update()
    {
        if (hearts <= 0)
        {
            SceneManager.LoadScene("over");
        }
    }

    public void TakeDamage(int damage)
    {
        hearts -= damage;
    }
        
}
