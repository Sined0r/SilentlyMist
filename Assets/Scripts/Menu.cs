using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject second;

    private void Start()
    {
        main.SetActive(true);
        second.SetActive(false);
    }

    public void No()
    {
        main.SetActive(true);
        second.SetActive(false);
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ArSure()
    {
        main.SetActive(false);
        second.SetActive(true);
    }


    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
