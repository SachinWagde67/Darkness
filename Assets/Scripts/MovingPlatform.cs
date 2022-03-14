using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] waypoint;
 
    private int currentIndex = 0;

    void Update()
    {
        if(Vector2.Distance(waypoint[currentIndex].transform.position,transform.position) < 0.1f)
        {
            currentIndex++;
            if(currentIndex >= waypoint.Length)
            {
                currentIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentIndex].transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<CharacterController2D>() != null)
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<CharacterController2D>() != null)
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
