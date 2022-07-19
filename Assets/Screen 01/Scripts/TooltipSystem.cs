using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem curr;

    [SerializeField]
    private Tooltips tooltips;
    private void Awake()
    {
        curr = this;
    }

    public static void Show(string content, string header = "")
    {
        curr.tooltips.SetText(content, header);
        curr.tooltips.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        curr.tooltips.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
}
