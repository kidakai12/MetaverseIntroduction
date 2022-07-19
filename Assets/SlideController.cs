using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlideController : MonoBehaviour
{
    public RawImage raw;

    public void NextSlide()
    {
        raw.GetComponent<LoadImageSlide>().next();
    }
    public void PreviousSlide()
    {
        raw.GetComponent<LoadImageSlide>().previous();
    }
}
