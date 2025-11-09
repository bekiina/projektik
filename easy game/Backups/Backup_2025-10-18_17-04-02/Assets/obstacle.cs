using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    

    void Start()
    {
     
    }


    void Update()
    {
       rb.velocity = new Vector2( moveSpeed, 0f);  
    }
}