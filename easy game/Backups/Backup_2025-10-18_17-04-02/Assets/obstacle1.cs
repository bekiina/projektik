using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle1 : MonoBehaviour
{
    [SerializeField] float moveSpeed = -5f;
    [SerializeField] Rigidbody2D rb;
    

    void Start()
    {
        Vector3 scale = transform.localScale;
        scale.x = -Mathf.Abs(scale.x); 
        transform.localScale = scale;
    }


    void Update()
    {
       rb.velocity = new Vector2(-Mathf.Abs(moveSpeed), 0f);  
    }
}