using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Button backButton;
    public Button applyBurtton;
    private int SceneHistory;
    private Toggle invertY;
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(Back);
    }
    public void Back()
    {
        SceneHistory = PlayerPrefs.GetInt("Previous");
        SceneManager.LoadScene(SceneHistory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
