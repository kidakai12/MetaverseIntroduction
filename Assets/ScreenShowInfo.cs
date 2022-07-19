using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenShowInfo : MonoBehaviour
{
    public RawImage rawImg;
    public RawImage showRaw;
    public Image image;
    public string ImgInfo = "hello";
    public GameObject canvas;
    public Camera Object;
    public Texture2D tex;
    public void Start()
    {
        rawImg.texture = tex;
        tex.anisoLevel = 16;

        RectTransform rectRaw = rawImg.GetComponent<RectTransform>();

        double fraction = (float)tex.width / (float)tex.height;
        float height = 1 / (float)fraction;

        rectRaw.sizeDelta = new Vector2(1, height);

        rawImg.texture = tex;
        SizeToParent(rawImg, 0);
    }
    public static Vector2 SizeToParent(RawImage image, float padding)
    {
        float w = 0, h = 0;
        var parent = image.GetComponentInParent<RectTransform>();
        var imageTransform = image.GetComponent<RectTransform>();

        // check if there is something to do
        if (image.texture != null)
        {
            if (!parent) { return imageTransform.sizeDelta; } //if we don't have a parent, just return our current width;
            padding = 1 - padding;
            float ratio = image.texture.width / (float)image.texture.height;
            var bounds = new Rect(0, 0, parent.rect.width, parent.rect.height);
            if (Mathf.RoundToInt(imageTransform.eulerAngles.z) % 180 == 90)
            {
                //Invert the bounds if the image is rotated
                bounds.size = new Vector2(bounds.height, bounds.width);
            }
            //Size by height first
            h = bounds.height * padding;
            w = h * ratio;
            if (w > bounds.width * padding)
            { //If it doesn't fit, fallback to width;
                w = bounds.width * padding;
                h = w / ratio;
            }
        }
        imageTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, w);
        imageTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, h);
        return imageTransform.sizeDelta;
    }
    public void GetImgInfo()
    {
        canvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 3.52f;
        canvas.transform.LookAt(Object.transform);
        RectTransform rectRaw = rawImg.GetComponent<RectTransform>();
        RectTransform rectRaw2 = showRaw.GetComponent<RectTransform>();
        rectRaw2.sizeDelta = rectRaw.sizeDelta;
        showRaw.texture = rawImg.texture;
        canvas.active = true;
    }
}
