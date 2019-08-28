using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float boundY = -6f;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;

        if (temp.y <= boundY)
        {
            Destroy(gameObject);
        }

    }
}
