using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class SceneSpheres : MonoBehaviour
{
    public RawImage Render;
    public AudioSource Music;
    public Transform Cam;
    public Transform Cam0;
    public Transform Cam1;
    public Transform Cam2;
    public Transform Cam3;
    public VisualEffect Particles;
    public Material SphereRef;
    public Material SphereGlow;
    public Transform SpheresRoot;
    public GameObject NextScene;
    public Transform Spheres;

    private float _Timer = 0.0f;
    private float _ChangeTimer = 0.0f;
    private float _SphereTimer = 0.0f;
    private int _CamID = 0;

    private void OnEnable()
    {
        RenderUI.Get().Print("MonoBleedingEdge\nRandomFields.exe \nRandomFields_Data \nUnityCrashHandler64.exe \nUnityPlayer.dll \nEmbedRuntime \netc \nmono-2.0-bdwgc.dll \nMonoPosixHelper.dll \nmono \n2.0 \n4.0 \n4.5 \nbrowscap.ini \nconfig \nmconfig \nBrowsers \nDefaultWsdlHelpGenerator.aspx \nmachine.config \nsettings.map \nweb.config \nCompat.browser \nBrowsers \nDefaultWsdlHelpGenerator.aspx \nmachine.config \nsettings.map \nweb.config \nCompat.browser \nBrowsers \nDefaultWsdlHelpGenerator.aspx \nmachine.config \nsettings.map \nweb.config \nCompat.browser \nconfig.xml \napp.info \nboot.config \nglobalgamemanagers \nglobalgamemanagers.assets \nglobalgamemanagers.assets.resS \nlevel0 \nManaged \nResources \nresources.assets \nresources.assets.resS \nsharedassets0.assets \nsharedassets0.assets.resS \nsharedassets0.resource \nAssembly-CSharp.dll \nMono.Security.dll \nmscorlib.dll \nnetstandard.dll \nSystem.ComponentModel.Composition.dll \nSystem.Configuration.dll");
    }

    private void OnDisable()
    {
        RenderUI.Get().Clear();
    }

    void Update()
    {
        Spheres.Rotate(Vector3.up, Time.deltaTime*40.0f*(0.5f+SoundController.Get().Bass));

        _Timer += Time.deltaTime;
        _ChangeTimer += Time.deltaTime;

        if (SoundController.Get().Bass>=1.0f && _ChangeTimer>1.5f)
        {
            _ChangeTimer = 0.0f;
            _Timer = 0.0f;

            if (Music.time>95.0f && _CamID==0)
            {
                _CamID = 1;
                RenderUI.Get().Clear();
            }
        }

        float lerp = _Timer*0.5f;

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

        Particles.SetFloat("Rate", SoundController.Get().Bass*6000.0f);

        _SphereTimer += Time.deltaTime;
        if (_SphereTimer>0.2f)
        {
            _SphereTimer = 0.0f;
            for (int i=0 ; i<40 ; ++i)
                SpheresRoot.GetChild((int)(Random.value*(SpheresRoot.childCount-1))).GetComponent<Renderer>().material = Random.value>0.9f?SphereGlow:SphereRef;
        }

        if (Music.time>=110.0f)
        {
            gameObject.SetActive(false);
            NextScene.SetActive(true);
        }
    }
}