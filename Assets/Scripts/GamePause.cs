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
        GamePauseCanvas.SetActive(false);
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void PauseBtn()
    {
        GamePauseCanvas.SetActive(true);
        GamePauseCanvas.GetComponent<Animator>().SetTrigger("gamepause");
        Invoke(nameof(gamePause),1.1f);
    }

    private void gamePause()
    {
        Time.timeScale = 0f;

    }
}
