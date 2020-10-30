using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deform : MonoBehaviour
{
    public AudioSource Music;
    public RawImage Render;
    public Texture2D[] ScreenDeforms;

    private float _ScreenDeformsRandom = 0.0f;

    // Update is called once per frame
    void Update()
    {
        _ScreenDeformsRandom += Time.deltaTime;
        if (_ScreenDeformsRandom>0.4f)
        {
            Render.material.SetFloat("_DeformInvert", Random.value);
            _ScreenDeformsRandom = 0.0f;
        }
        Render.material.SetTexture("_DeformTex", ScreenDeforms[((int)(Music.time*20.0f))%ScreenDeforms.Length]);
    }
}
