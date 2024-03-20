using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public GameObject TimeCanv;
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (TimeCanv.activeInHierarchy)
        {
            timer += Time.deltaTime;
            timerText.text = string.Format("{0:0}:{1:00}.{2:00}", timer / 60, timer % 60, timer * 100 % 100);
        }
    }
}
