using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private float direction = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * direction, 0f);
    }

    public void SetDirection(float dir)
    {
        direction = dir;
    }
}
