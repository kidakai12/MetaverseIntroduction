using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class LoadImageSlide : MonoBehaviour
{
    public Image img;
    public RawImage image;
    public Texture2D[] texList;
    public Texture2D currentTex;
    public int currentSlide;
    public int TotalSlides;

    public void LoadSlide()
    {
        currentTex = texList[currentSlide];
        currentTex.anisoLevel = 16;

        RectTransform rectRaw = image.GetComponent<RectTransform>();
        RectTransform rectContainer = img.GetComponent<RectTransform>();

        double fraction = (float)currentTex.width / (float)currentTex.height;
        float height = 1920 / (float)fraction;

        rectContainer.sizeDelta = new Vector2(1920F, height);
        rectRaw.sizeDelta = new Vector2(1920F, height);

        image.texture = currentTex;
        SizeToParent(image, 0);
    }
    public void next()
    {
        if (currentSlide == (TotalSlides - 1))
            currentSlide = -1;
        currentSlide++;
        currentTex = texList[currentSlide];
        currentTex.anisoLevel = 16;

        RectTransform rectRaw = image.GetComponent<RectTransform>();
        RectTransform rectContainer = img.GetComponent<RectTransform>();

        double fraction = (float)currentTex.width / (float)currentTex.height;
        float height = 1920 / (float)fraction;

        rectContainer.sizeDelta = new Vector2(1920F, height);
        rectRaw.sizeDelta = new Vector2(1920F, height);

        image.texture = currentTex;
        SizeToParent(image, 0);
    }

    public void previous()
    {
        if (currentSlide == 0)
            currentSlide = TotalSlides;
        currentSlide--;
        currentTex = texList[currentSlide];
        currentTex.anisoLevel = 16;

        RectTransform rectRaw = image.GetComponent<RectTransform>();
        RectTransform rectContainer = img.GetComponent<RectTransform>();

        double fraction = (float)currentTex.width / (float)currentTex.height;
        float height = 1920 / (float)fraction;

        rectContainer.sizeDelta = new Vector2(1920F, height);
        rectRaw.sizeDelta = new Vector2(1920F, height);

        image.texture = currentTex;
        SizeToParent(image, 0);
    }
    IEnumerator LoadImage(string imageUrl)
    {
        WWW www = new WWW(imageUrl);
        //loading.SetActive(true);
        yield return www;

        if (www.error == null)
        {
            //loading.SetActive(false);
            Texture2D texture = www.texture;
            texture.anisoLevel = 16;
            RectTransform rectRaw = image.GetComponent<RectTransform>();
            RectTransform rectContainer = img.GetComponent<RectTransform>();
            double fraction = (float)texture.width / (float)texture.height;
            Debug.Log("Height: " + fraction);
            float height = 1920 / (float)fraction;
            Debug.Log("Height: " + height);
            rectContainer.sizeDelta = new Vector2(1920F, height);
            rectRaw.sizeDelta = new Vector2(1920F, height);
            image.texture = texture;
            SizeToParent(image, 0);

        }
        else

        {
            Debug.Log(www.error);
        }
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

}
