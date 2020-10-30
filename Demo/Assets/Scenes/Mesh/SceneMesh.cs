using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class SceneMesh : MonoBehaviour
{
    public RawImage Render;
    public AudioSource Music;
    public Transform Cam;
    public Transform Cam0;
    public Transform Cam1;
    public Transform Cam2;
    public Transform Cam3;
    public Transform Whales;
    public GameObject NextScene;

    private float _Timer = 0.0f;
    private float _ChangeTimer = 0.0f;
    private int _CamID = 0;

    void Update()
    {
        Render.GetComponent<AspectRatio>().FieldFx.gameObject.SetActive(true);

        for (int i=0 ; i<Whales.childCount ; ++i)
        {
            Animation anim = Whales.GetChild(i).GetComponent<Animation>();
            if (!anim.isPlaying)
                anim.Play();
        }

        _Timer += Time.deltaTime;
        _ChangeTimer += Time.deltaTime;

        if (SoundController.Get().Bass>=1.0f && _ChangeTimer>0.8f)
        {
            _ChangeTimer = 0.0f;
            _Timer = 0.0f;
            _CamID = (_CamID+1)%2;
        }

        float lerp = _Timer*0.3f;

        if (_CamID==0)
        {
            Cam.transform.position = Vector3.Lerp(Cam0.position, Cam1.position, lerp);
            Cam.transform.rotation = Quaternion.Lerp(Cam0.rotation, Cam1.rotation, lerp);
        }
        else
        {
            Cam.transform.position = Vector3.Lerp(Cam2.position, Cam3.position, lerp);
            Cam.transform.rotation = Quaternion.Lerp(Cam2.rotation, Cam3.rotation, lerp);
        }

        if (Music.time>=128.6f)
        {
            gameObject.SetActive(false);
            NextScene.SetActive(true);
        }
    }
}