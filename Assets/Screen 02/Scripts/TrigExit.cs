using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigExit : MonoBehaviour
{
    public static TrigExit instance;

    [HideInInspector]
    public HoverController currentCollider;

    [HideInInspector]
    public ScreenManager currentCollider2;

    [HideInInspector]
    public RobotController3 currentCollider3;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void OnDisable()
    {
        if(currentCollider != null)
            currentCollider.onExit.Invoke();
        if (currentCollider2 != null)
            currentCollider2.onExit.Invoke();
        if (currentCollider3 != null)
            currentCollider3.onExit.Invoke();
    }
}
