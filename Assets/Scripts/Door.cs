using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    

    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer play;
    [SerializeField] private GameObject doorIcon;
    [SerializeField] private Transform WayPoint;
    [SerializeField] private GameObject CameraDisable;
    [SerializeField] private GameObject CameraEnable;
    [SerializeField] private Animator anim;

    private bool isDoor = false;

    private void Awake()
    {
        doorIcon.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isDoor)
        {
            StartCoroutine(DoorAnim());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorIcon.SetActive(true);
            isDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorIcon.SetActive(false);
            isDoor = false;
        }
    }

    private IEnumerator DoorAnim()
    {

        player.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        anim.SetTrigger("play");
        yield return new WaitForSeconds(1f);
        CameraDisable.SetActive(false);
        CameraEnable.SetActive(true);
        player.transform.position = WayPoint.transform.position;
        player.SetActive(true);
        play.enabled = true;
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("end");
    }



}
