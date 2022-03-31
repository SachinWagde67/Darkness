using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private GameObject GameCompleteCanvas;
    [SerializeField] public GameObject GamePauseCanvas;

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResumeBtn()
    {
        GamePauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void NextBtn(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lobby");
    }

    public void PauseBtn()
    {
        GamePauseCanvas.gameObject.SetActive(true);
        GamePauseCanvas.GetComponent<Animator>().SetTrigger("gamepause");
        gamePause();
    }

    private async void gamePause()
    {
        await new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }

    public void onPlayerDeath()
    {
        GameOverCanvas.SetActive(true);
        GameOverCanvas.GetComponent<Animator>().SetTrigger("gameover");
    }

    public void onPlayerWin()
    {
        GameCompleteCanvas.SetActive(true);
        GameCompleteCanvas.GetComponent<Animator>().SetTrigger("gamecomplete");
    }
}
