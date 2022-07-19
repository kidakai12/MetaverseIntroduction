using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipsTrigger : MonoBehaviour
{

    [SerializeField]
    [Multiline()]
    private string content;
    [SerializeField]
    private string header;
    public void OnMouseEnter()
    {
        TooltipSystem.Show(content,header);
    }

    public void OnMouseExit()
    {
        TooltipSystem.Hide();
    }
}
