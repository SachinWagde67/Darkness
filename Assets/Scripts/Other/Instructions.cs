using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] private GameObject InstructionText;

    void Start()
    {
        InstructionText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<CharacterController2D>() != null)
        {
            InstructionText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<CharacterController2D>() != null)
        {
            InstructionText.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
