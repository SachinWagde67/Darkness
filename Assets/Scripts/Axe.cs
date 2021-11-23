using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool movingClockwise;

    [SerializeField] private float speed;
    [SerializeField] float leftAngle;
    [SerializeField] float rightAngle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movingClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void ChangeMoveDir()
    {
        if(transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if(transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    private void Move()
    {
        ChangeMoveDir();

        if(movingClockwise)
        {
            rb.angularVelocity = speed * 10;
        }
        if (!movingClockwise)
        {
            rb.angularVelocity = -1 * speed * 10;
        }
    }
}
