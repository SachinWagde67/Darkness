using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private GameObject LobbyPanel;
    [SerializeField] private GameObject InstructionPanel;

    private void Awake()
    {
        LobbyPanel.SetActive(true);
        InstructionPanel.SetActive(false);
    }

    public void NewGameBtn(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void InstructionBtn()
    {
        LobbyPanel.SetActive(false);
        InstructionPanel.SetActive(true);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void backbtn()
    {
        LobbyPanel.SetActive(true);
        InstructionPanel.SetActive(false);
    }
}
