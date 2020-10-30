using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RenderUI : MonoBehaviour
{
    private const int _MaxLines = 13;

    public Canvas RenderCanvas;
    public TMPro.TextMeshProUGUI TxtUI;
    public TMPro.TextMeshProUGUI OverTxt;

    private string _Txt = "";
    private float _Len = 0.0f;
    private float _Timer = 0.0f;
    private float _Speed;

    private static RenderUI _Instance = null;
    
    private void Awake()
    {
        _Instance = this;
        TxtUI.alignment = TextAlignmentOptions.TopLeft;
        _Speed = 10.0f;
        OverTxt.text = "";
    }

    public static RenderUI Get()
    {
        return _Instance;
    }

    public void Center()
    {
        TxtUI.alignment = TextAlignmentOptions.Center;
        _Speed = 20.0f;
    }

    public void Print(string txt)
    {
        if (_Txt.Length>0)
            _Txt += "\n";
        _Txt += txt;
    }

    public void Clear()
    {
        _Txt = "";
        _Len = 0.0f;
    }
    
    void Update()
    {        
        _Timer += Time.deltaTime;

        Camera[] cameras = GameObject.FindObjectsOfType<Camera>();
        RenderCanvas.worldCamera = Array.Find(cameras, c=>c.gameObject.name!="EmptyCamera");
    
        _Len = Mathf.Clamp(_Len+Time.deltaTime*_Speed, 0.0f, (float)_Txt.Length);
        string str = _Txt.Substring(0, (int)_Len);
        int count = 0;
        for (int i=str.Length-1 ; i>0 ; --i)
        {
            if (str[i]=='\n')
            {
                ++count;
                if (count>=_MaxLines)
                {
                    str = str.Substring(i+1);
                    break;
                }
            }   
        }

        if (Mathf.Sin(_Timer*14.0f)>0.0f)
            str += "_";
        TxtUI.text = str;
    }
    
}
