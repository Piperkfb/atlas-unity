using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button lvl1;
    public Button lvl2;
    public Button lvl3;
    public Button optionsButton;
    public Button exitButton;
    private int SceneHistory;

    // Start is called before the first frame update
    void Start()
    {
        SceneHistory = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Previous", SceneHistory);
        lvl1.onClick.AddListener(delegate {LevelSelect(1);});
        lvl2.onClick.AddListener(delegate {LevelSelect(2);});
        lvl3.onClick.AddListener(delegate {LevelSelect(3);});

        optionsButton.onClick.AddListener(Options);
        exitButton.onClick.AddListener(exitProgram);
    }
    public void LevelSelect(int lvl)
    {
        SceneManager.LoadScene("Level0" + lvl);
        
    }

    public void Options()
    {   
        SceneManager.LoadScene("Options");
    }
    public void exitProgram()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
