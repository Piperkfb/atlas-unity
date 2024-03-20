using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneCamera : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject PlayContr;
    public GameObject TimeCanv;
    public Animator CutControl;
    // Start is called before the first frame update
    void Start()
    {
        CutControl = GetComponent<Animator>();
        CutControl.Play("Intro01", 0, 0.0f);
        Invoke("startScene", 2.0f);
    }

    private void startScene()
    {
        MainCam.SetActive(true);
        PlayContr.GetComponent<PlayerController>().enabled = true;
        TimeCanv.SetActive(true);
        CutControl.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //CutControl.SetBool("Level01", true);
        }
}