using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class HoverController : MonoBehaviour
{
    [SerializeField]
    private AudioSource HOVER_SOUND;

    [SerializeField]
    private AudioSource CLICK_SOUND;

    [SerializeField]
    private UnityEvent onEnter;

    [SerializeField]
    public UnityEvent onExit;

    private Renderer rend;

    [SerializeField]
    private Material[] materials;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private GameObject currentScreen;

    [SerializeField]
    private GameObject goToScreen;

    [SerializeField]
    private RawImage image;

    [SerializeField]
    private Texture2D currentTex;

    [SerializeField]
    private Image img;

    public Texture2D[] slideImages;

    public GameObject nextSlide;
    public GameObject previousSlide;
    private void OnTriggerEnter(Collider other)
    {
        TrigExit.instance.currentCollider = GetComponent<HoverController>();
        onEnter.Invoke();
    }
    private void Start()
    {
        rend = panel.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
    }
    public void HoverEnter()
    {
        HOVER_SOUND.Play();
        ChangeMaterials(1);
        transform.DOScale(new Vector3(13.7204f + 0.2f, 13.7204f + 0.2f, 13.7204f + 0.2f), 0.5f);
    }
    public void HoverEnter2()
    {
        HOVER_SOUND.Play();
        ChangeMaterials(1);
        transform.DOScale(new Vector3(10f + 0.2f, 10f + 0.2f, 10f + 0.2f), 0.5f);
    }
    public void HoverExit()
    {
        ChangeMaterials(0);
        transform.DOScale(new Vector3(13.7204f, 13.7204f, 13.7204f), 0.5f);
    }
    public void HoverExit2()
    {
        ChangeMaterials(0);
        transform.DOScale(new Vector3(10f, 10f, 10f), 0.5f);
    }
    void ChangeMaterials(int n)
    {
        rend.sharedMaterial = materials[n];
    }

    private void OnMouseDown()
    {
        TriggerSlide();
    }
    public void TriggerPanel()
    {
        CLICK_SOUND.Play();
        currentScreen.active = false;
        goToScreen.active = true;
        //StartCoroutine("TriggerAnimation");
    }
    public void TriggerSlide()
    {
        CLICK_SOUND.Play();

        LoadImageSlide slide = image.GetComponent<LoadImageSlide>();

        slide.texList = slideImages;
        slide.currentSlide = 0;
        slide.TotalSlides = slideImages.Length;
        slide.LoadSlide();
        previousSlide.GetComponent<SlideController>().raw = image;

        nextSlide.GetComponent<SlideController>().raw = image;

        currentTex = slideImages[0];

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

    public void TriggerScene()
    {
        SceneManager.LoadScene("outpost on desert");
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
