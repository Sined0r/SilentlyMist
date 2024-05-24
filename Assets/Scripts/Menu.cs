using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject second;
    [SerializeField] GameObject key;

    [SerializeField] AudioSource _audio;
    [SerializeField] AudioSource _music;

    private void Start()
    {
        main.SetActive(true);
        second.SetActive(false);
        key.SetActive(false);
        _music.Play();
    }

    public void No()
    {
        main.SetActive(true);
        second.SetActive(false);
        key.SetActive(false);
        _audio.Play();
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        _audio.Play();
    }

    public void ExitGame()
    {
        Application.Quit();
        _audio.Play();
    }

    public void ArSure()
    {
        main.SetActive(false);
        second.SetActive(true);
        _audio.Play();
    }

    public void Keybords()
    {
        main.SetActive(false);
        second.SetActive(false);
        key.SetActive(true);
        _audio.Play();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        _audio.Play();
    }
}
