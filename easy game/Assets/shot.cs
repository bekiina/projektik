using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class shot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            GameObject newBullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

            // Set bullet direction 
            float direction = transform.localScale.x > 0 ? 1f : -1f;

            // Flip bullet 
            if (direction < 0)
            {
                Vector3 scale = newBullet.transform.localScale;
                scale.x *= -1;
                newBullet.transform.localScale = scale;
            }

            newBullet.GetComponent<bullet>().SetDirection(direction);
        }
    }
}
