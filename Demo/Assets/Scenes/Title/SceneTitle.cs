using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class SceneTitle : MonoBehaviour
{
    public RawImage Render;
    public AudioSource Music;
    public Transform Cam;
    public Transform Cam0;
    public Transform Cam1;
    public VisualEffect Particles;    
    public GameObject NextScene;

    private float _Timer = 0.0f;

    void Start()
    {
        Particles.SetFloat("Rate", 0.0f);
        RenderUI.Get().Clear();
        RenderUI.Get().Print("Random Fields");
    }

    void Update()
    {
        _Timer += Time.deltaTime;

        if (_Timer>=5.0f && _Timer<10.0f)
        {
            RenderUI.Get().OverTxt.text = "RANDOM FIELDS";
        }
        else
        {
            RenderUI.Get().OverTxt.text = "";
        }
        
        Particles.SetFloat("Rate", ((Music.time<40.0f && _Timer>1.0f)?300000.0f:0.0f)*SoundController.Get().Bass);
            
        float lerp = Mathf.Sin(Music.time*0.6f)*0.5f+0.5f;
        Cam.transform.position = Vector3.Lerp(Cam0.position, Cam1.position, lerp);
        Cam.transform.rotation = Quaternion.Lerp(Cam0.rotation, Cam1.rotation, lerp);

        if (Music.time>=40.7f)
        {
            RenderUI.Get().Clear();
            gameObject.SetActive(false);
            NextScene.SetActive(true);
        }
     }
}