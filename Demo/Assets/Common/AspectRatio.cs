using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectRatio : MonoBehaviour
{
    public Canvas RenderCanvas;
    public RawImage RenderFrame;
    public RawImage FieldFx;

    void Awake()
    {
        int width = (int)RenderCanvas.pixelRect.width;
        int height = (int)(width * 1.0f / 2.20f);

        if (height> RenderCanvas.pixelRect.height)
        {
            height = (int)RenderCanvas.pixelRect.height;
            width = (int)(height * 2.20f / 1.0f);
        }

        RenderFrame.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        RenderFrame.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);

        float h = height*0.2f;
        float w = h*1728.0f/687.0f;
        FieldFx.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, w);
        FieldFx.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, h);
        FieldFx.rectTransform.anchoredPosition = new Vector2(h*0.3f, h*0.3f);
        FieldFx.gameObject.SetActive(false);
    }

}
