
using UnityEngine;
using UnityEngine.Events;
public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onEnter;
    [SerializeField]
    public UnityEvent onExit;
    private Renderer rend;
    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private GameObject[] currentScreen;
    [SerializeField]
    private GameObject goToScreen;


    private void OnTriggerEnter(Collider other)
    {
        TrigExit.instance.currentCollider2 = GetComponent<ScreenManager>();
        onEnter.Invoke();
    }
    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
    }
    public void HoverEnter()
    {
        ChangeMaterials(1);
    }

    public void HoverExit()
    {
        ChangeMaterials(0);
    }
    void ChangeMaterials(int n)
    {
        rend.sharedMaterial = materials[n];
    }

    public void TriggerPanel()
    {
        foreach (GameObject g in currentScreen)
            g.active = false;
        goToScreen.active = true;
    }
}
