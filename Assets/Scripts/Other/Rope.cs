using UnityEngine;

public class Rope : MonoBehaviour
{
    private HingeJoint2D HingeJoint;

    private void Awake()
    {
        HingeJoint = GetComponent<HingeJoint2D>();
    }

    void Start()
    {
        HingeJoint.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("sword"))
        {
            HingeJoint.enabled = false;
            Invoke(nameof(DisableOject), 1f);
        }
    }

    private void DisableOject()
    {
        this.gameObject.SetActive(false);
    }

}
