using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private CharacterController2D player;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<CharacterController2D>() != null)
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Vector2 rayDirection = (other.transform.position - transform.position);
            RaycastHit2D hitlight = Physics2D.Raycast(transform.position, rayDirection, distance, playerLayer);
            
            if (hitlight.collider != null && hitlight.collider.GetComponent<CharacterController2D>() != null)
            {
                player.Death();
            }
        }
    }
}
