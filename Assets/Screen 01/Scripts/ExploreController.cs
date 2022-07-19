
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
public class ExploreController : MonoBehaviour
{

    [SerializeField]
    private UnityEvent onEnter;
    [SerializeField]
    public UnityEvent onExit;
    private Renderer rend;
    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private GameObject currentScreen;
    [SerializeField]
    private GameObject goToScreen;


    private void OnTriggerEnter(Collider other)
    {
        TrigExit.instance.currentCollider = GetComponent<HoverController>();
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
        transform.DOScale(new Vector3(14.3f, 14.3f, 14.3f), 0.5f);
    }

    public void HoverExit()
    {
        ChangeMaterials(0);
        transform.DOScale(new Vector3(14f, 14f, 14f), 0.5f);
    }
    void ChangeMaterials(int n)
    {
        rend.sharedMaterial = materials[n];
    }

    public void TriggerPanel()
    {
        currentScreen.active = false;
        goToScreen.active = true;
    }
}
