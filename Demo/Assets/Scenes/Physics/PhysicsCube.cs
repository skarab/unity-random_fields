using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCube : MonoBehaviour
{
    private const float _LifeTime = 12.0f;

    private float _Timer = 0.0f;

    void Update()
    {
        _Timer += Time.deltaTime;

        if (_Timer>_LifeTime)
            Destroy(gameObject);
    }
}
