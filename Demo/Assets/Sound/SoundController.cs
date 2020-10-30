using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;
using UnityEngine.VFX;

public class SoundController : MonoBehaviour
{
    public Volume[] PPVolumes;
    public AudioSource Music;
    public float Bass;
    public RawImage Render;

    private float _Timer = 0.0f;
    private static SoundController _Instance = null;

    private void Awake()
    {
        _Instance = this;
    
#if !UNITY_EDITOR
        Cursor.visible = false;
#endif
    }

    public static SoundController Get()
    {
        return _Instance;
    }
     
    void Update()
    {
        _Timer += Time.deltaTime;
        if (_Timer>=2.0f && !Music.isPlaying)
            Music.Play();

        float[] spectrum = new float[256];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
        float v = 0.0f;
        for (int i=0 ; i<10 ; ++i)
            v += spectrum[i];

        Bass = Mathf.Clamp01(v);

        ChromaticAberration ca;
        FilmGrain gr;
        
        foreach (Volume pp in PPVolumes)
        {
            pp.sharedProfile.TryGet<ChromaticAberration>(out ca);
            ca.intensity.value = v;        
            pp.sharedProfile.TryGet<FilmGrain>(out gr);
            gr.intensity.value = 1.0f-v;
        }

        v = 0.0f;
        for (int i=210 ; i<256 ; ++i)
            v += Mathf.Abs(spectrum[i]);

        float s = ((Music.time<2.0f)
            || (Music.time>26.0f && Music.time<28.0f)
            || (Music.time>39.8f && Music.time<41.5f)
            || (Music.time>80.0f && Music.time<83.0f)
            || (Music.time>110.0f && Music.time<111.5f) 
            || (Music.time>138.0f))?1.0f:0.2f;

        if (Music.time>=128.6f)
            s = 0.5f;

        Render.material.SetFloat("_Deform", s);
       
#if !UNITY_EDITOR
        if (Music.time>=157.0f || Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
#endif
    }
}
