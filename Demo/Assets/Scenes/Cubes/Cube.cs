using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _Glow;
    private float _Offset;

    void Start()
    {
        _Glow = transform.Find("Glow").gameObject.GetComponent<Renderer>();
        _Offset = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        _Glow.sharedMaterial.SetFloat("_EmissiveIntensity", (SoundController.Get().Bass-0.8f)*10000.0f);
        _Glow.transform.localPosition = new Vector3(0.0f, Mathf.Clamp(SoundController.Get().Bass*4.0f, 0.0f, 1.317f+_Offset), 0.0f);
    }
}
