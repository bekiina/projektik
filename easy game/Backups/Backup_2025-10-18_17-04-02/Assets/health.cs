using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public int playerHealth;

    [SerializeField] private Image[] hearths;
    [SerializeField] private Sprite fullHearth;
    [SerializeField] private Sprite emptyHearth;
    [SerializeField] private string gameOverSceneName = "over";

    void Start()
    {
        UpdateHealth();
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        playerHealth = Mathf.Clamp(playerHealth, 0, hearths.Length);
        UpdateHealth();

        if (playerHealth <= 0 )
        {
            Die();
        }

    }

    private void Die()
    {
        SceneManager.LoadScene( gameOverSceneName );
    }
        

    public void UpdateHealth()
    {
        for (int i = 0; i < hearths.Length; i++)
        {
            if (i < playerHealth)
            {
                hearths[i].sprite = fullHearth;
            }
            else
            {
                hearths[i].sprite = emptyHearth;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            TakeDamage(1);
        }
    }
}
