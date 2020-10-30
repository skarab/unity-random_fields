using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class SceneFinal : MonoBehaviour
{
    public RawImage Render;
    public AudioSource Music;
    

    void OnEnable()
    {
        Render.GetComponent<AspectRatio>().FieldFx.gameObject.SetActive(false);

        RenderUI.Get().Center();
        RenderUI.Get().Print("Random Fields\n\nRebels, 2020\n\nSkarab (code)\nTeo (Music)\n\nfirst shown at FieldFX online 2020\npresented in 2.20:1\n\nOrkney open source font\nMax P (lens texture)\nRkuhl (whale model)\n\nadapt\naenima\nand\nblasphemy\nbrainstorm\ncocoon\ncondense\ncritical mass\ndeadliners\ndesire\ndigital murder\nekspert\nfairlight\nfarbrausch\nflush\nkiki-prods\nknights\nlemon.\nlimp ninja\nlnx\npopsy team\nresistance\nskarla\nstill\nsuburban\nsyn[rj]\nthe lost souls\ntitan\ntraction\ntrsi\n\n\nCopyright © Rebels, 25 July 2020");
    }

    void Update()
    {
        if (Music.time>=153.0f)
            Render.material.SetFloat("_FadeOut", Mathf.MoveTowards(Render.material.GetFloat("_FadeOut"), 1.0f, Time.deltaTime*0.4f));
    }
}