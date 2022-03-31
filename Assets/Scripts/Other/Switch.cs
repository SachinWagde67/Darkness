using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject s1;
    [SerializeField] private GameObject s2;
    [SerializeField] private GameObject movingPlatform;

    private void Start()
    {
        s1.SetActive(true);
        s2.SetActive(false);
        movingPlatform.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("sword"))
        {
            s1.SetActive(false);
            s2.SetActive(true);
            movingPlatform.SetActive(true);
        }
    }
}
