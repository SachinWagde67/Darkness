using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private CharacterController2D player;

    [SerializeField] private SpriteRenderer play;
    [SerializeField] private Transform WayPoint;
    [SerializeField] private GameObject CameraDisable;
    [SerializeField] private GameObject CameraEnable;
    [SerializeField] private Animator anim;

    public GameObject doorIcon;
    public bool isDoor = false;

    private void Awake()
    {
        doorIcon.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isDoor)
        {
            DoorAnim();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<CharacterController2D>() != null)
        {
            doorIcon.SetActive(true);
            isDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<CharacterController2D>() != null)
        {
            doorIcon.SetActive(false);
            isDoor = false;
        }
    }

    private async void DoorAnim()
    {
        player.gameObject.SetActive(false);
        await new WaitForSeconds(0.1f);

        anim.SetTrigger("play");
        await new WaitForSeconds(1f);

        CameraDisable.SetActive(false);
        CameraEnable.SetActive(true);
        player.gameObject.transform.position = WayPoint.transform.position;
        player.gameObject.SetActive(true);
        play.enabled = true;
        await new WaitForSeconds(1f);

        anim.SetTrigger("end");
    }
}
