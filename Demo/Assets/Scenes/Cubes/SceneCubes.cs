using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class SceneCubes : MonoBehaviour
{
    public RawImage Render;
    public AudioSource Music;
    public Transform Cam;
    public Transform Cam0;
    public Transform Cam1;
    public GameObject NextScene;

    private float _Timer = 0.0f;
    private float _ChangeTimer = 0.0f;
    private float _UITimer = 0.0f;
    
    void Start()
    {
    }

    void Update()
    {
        float t = _UITimer+Time.deltaTime;

        if (t>1.0f && _UITimer<=1.0f)
        {
            RenderUI.Get().OverTxt.text = "MUSIC: TEO";
        }
        else if (t>6.0f && _UITimer<=6.0f)
        {
            RenderUI.Get().OverTxt.text = "";
        }
        else if (t>7.0f && _UITimer<=7.0f)
        {
            RenderUI.Get().OverTxt.text = "CODE: SKARAB";
        }
        else if (t>12.0f && _UITimer<=12.0f)
        {
            RenderUI.Get().OverTxt.text = "";
        }

        _UITimer = t;
        _Timer += Time.deltaTime;
        _ChangeTimer += Time.deltaTime;

        if (SoundController.Get().Bass>=1.0f && _ChangeTimer>0.8f)
        {
            _ChangeTimer = 0.0f;
            _Timer = 0.0f;
        }

        float lerp = _Timer*0.5f;

        Cam.transform.position = Vector3.Lerp(Cam0.position, Cam1.position, lerp);
        Cam.transform.rotation = Quaternion.Lerp(Cam0.rotation, Cam1.rotation, lerp);

        if (Music.time>=54.5f)
        {
            gameObject.SetActive(false);
            NextScene.SetActive(true);
        }
     }
}