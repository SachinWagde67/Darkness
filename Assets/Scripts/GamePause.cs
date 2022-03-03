using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject GamePauseCanvas;

    public void ResumeBtn()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }

    public void ExitBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lobby");
    }

    public void PauseBtn()
    {
        this.gameObject.SetActive(true);
        GamePauseCanvas.GetComponent<Animator>().SetTrigger("gamepause");
        Invoke(nameof(gamePause),1.1f);
    }

    private void gamePause()
    {
        Time.timeScale = 0f;
    }
}
