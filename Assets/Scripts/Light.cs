using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private CharacterController2D player;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Vector2 rayDirection = (other.transform.position - transform.position);
            RaycastHit2D hitlight = Physics2D.Raycast(transform.position, rayDirection, distance, playerLayer);
            
            if (hitlight.collider != null && hitlight.collider.CompareTag("Player"))
            {
                Debug.DrawRay(transform.position, rayDirection, Color.red, 2f);
                player.Death();
            }
        }
    }
}
