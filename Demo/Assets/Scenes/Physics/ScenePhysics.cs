using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class ScenePhysics : MonoBehaviour
{
    private const float _GenTime = 0.1f;
    private const float _PosRandom = 2.0f;

    public RawImage Render;
    public AudioSource Music;
    public Transform Cam;
    public Transform Cam0;
    public Transform Cam1;
    public Transform Cam2;
    public Transform Cam3;
    public GameObject CubePrefab;
    public Transform DynamicNodes;
    public Transform StartPosition;
    public GameObject NextScene;

    private float _Timer = 0.0f;
    private float _ChangeTimer = 0.0f;
    private float _GenTimer = 0.0f;
    private int _CamID = 0;

    void Start()
    {
    }

    private void OnDisable()
    {
        while (DynamicNodes.childCount>0)
            DestroyImmediate(DynamicNodes.GetChild(0).gameObject);
    }

    void Update()
    {
        _GenTimer += Time.deltaTime;
        if (_GenTimer>=_GenTime)
        {
            _GenTimer = 0.0f;

            GameObject node = GameObject.Instantiate<GameObject>(CubePrefab, DynamicNodes);
            node.transform.position = new Vector3(
                StartPosition.position.x+Random.value*_PosRandom-_PosRandom/2.0f,
                StartPosition.position.y,
                StartPosition.position.z+Random.value*_PosRandom-_PosRandom/2.0f);
        }
    
        _Timer += Time.deltaTime;
        _ChangeTimer += Time.deltaTime;

        if (SoundController.Get().Bass>=1.0f && _ChangeTimer>0.8f)
        {
            _ChangeTimer = 0.0f;
            _Timer = 0.0f;
            _CamID = (_CamID+1)%2;
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
        
        if (Music.time>=81.0f)
        {
            gameObject.SetActive(false);
            NextScene.SetActive(true);
        }
     }
}