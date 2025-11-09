using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class demage : MonoBehaviour
{
    [SerializeField] private int zombieDamage;
    [SerializeField] private health _health;
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        _health.playerHealth = _health.playerHealth - zombieDamage;
        _health.UpdateHealth();
        gameObject.SetActive(false);
    }
}
