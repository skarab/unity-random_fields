using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class SceneLogo : MonoBehaviour
{
    public RawImage Render;
    public AudioSource Music;
    public Transform Cam;
    public Transform Cam0;
    public Transform Cam1;
    public VisualEffect Particles;    
    public GameObject NextScene;

    private float _Timer = 0.0f;
    private float _Fade = 0.0f;

    void Start()
    {
        Render.material.SetFloat("_FadeOut", 1.0f);
        Particles.SetFloat("Fade", 0.0f);
        Particles.SetFloat("Rate", 0.0f);
    }

    void Update()
    {
        if (!Music.isPlaying)
            return;

        Render.material.SetFloat("_FadeOut", Mathf.MoveTowards(Render.material.GetFloat("_FadeOut"), 0.0f, Time.deltaTime*0.33f));
    
        float lerp = Mathf.Sin(Music.time*0.6f)*0.5f+0.5f;
        Cam.transform.position = Vector3.Lerp(Cam0.position, Cam1.position, lerp);
        Cam.transform.rotation = Quaternion.Lerp(Cam0.rotation, Cam1.rotation, lerp);

        float t = _Timer+Time.deltaTime;
        if (t>0.2f && _Timer<=0.2f)
        {
            RenderUI.Get().Print("printf(\"Rebels\");");            
        }
        else if (t>6.3f && _Timer<=6.3f)
        {
            RenderUI.Get().Print("printf(\"presents\");");
        }
        else if (t>7.0f && _Timer<7.0f)
        {
            _Fade = 0.5f;
        }
        else if (t>13.0f && _Timer<=13.0f)
        {
            RenderUI.Get().Print("printf(\"at FieldFX 2020\");");
        }
        else if (t>16.0f && _Timer<16.0f)
        {
            _Fade = 1.0f;
        }
        
        Particles.SetFloat("Fade", Mathf.MoveTowards(Particles.GetFloat("Fade"), _Fade, Time.deltaTime*0.3f));
            

        _Timer = t;

        if (_Timer>4.0f)
            Particles.SetFloat("Rate", Mathf.Lerp(Particles.GetFloat("Rate"), 300000.0f, (_Timer-4.0f)*0.03f));

        if (Music.time>=26.5f)
        {
            gameObject.SetActive(false);
            NextScene.SetActive(true);
        }
     }
}