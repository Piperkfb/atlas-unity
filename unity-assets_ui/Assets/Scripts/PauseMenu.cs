using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton;
    public Button optionsButton;
    public Button resumeButton;
    public GameObject PMenu;
    // Start is called before the first frame update
    void Start()
    {

        restartButton.onClick.AddListener(Restart);
        menuButton.onClick.AddListener(MainMenu);
        optionsButton.onClick.AddListener(Options);
        resumeButton.onClick.AddListener(Resume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PMenu.activeInHierarchy)
            {
                Pause();
            }
            else
            {
                
                Resume();
            }
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PMenu.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PMenu.SetActive(false);
    }
    public void Restart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {
        int SceneHistory = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Previous", SceneHistory);
        SceneManager.LoadScene("Options");
        Time.timeScale = 1;
    }
}
