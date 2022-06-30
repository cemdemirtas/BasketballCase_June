using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinemachine : MonoBehaviour
{
    public static Cinemachine instance;
    Animator anim;
    bool IsMainCam = true;

    private void Awake() //Singleton Pattern.
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        IsMainCam = !IsMainCam;

    }

    public void MainCamMethod()
    {
        anim.Play("MainCamm");
        IsMainCam = false;
    }
    public void SideCamMethod()
    {
        anim.Play("SideCamera");
        IsMainCam = false;
    }
    public void UpwardCamMethod()
    {
        anim.Play("UpwardsCam");
        IsMainCam = false;
    }

}
