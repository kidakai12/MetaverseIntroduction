using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RobotController3 : MonoBehaviour
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
    private Renderer rend2;

    [SerializeField]
    private Material[] emote;

    [SerializeField]
    private AudioSource[] voices;

    public GameObject robot;
    public GameObject robotFace;
    [SerializeField]
    private Material[] materials;

    private int current = 0;

    private bool startCou = false;
    private void OnTriggerEnter(Collider other)
    {
        TrigExit.instance.currentCollider3 = GetComponent<RobotController3>();
        onEnter.Invoke();
    }
    private void Start()
    {
        rend = robot.GetComponent<Renderer>();
        rend2 = robotFace.GetComponent<Renderer>();
        rend.enabled = true;
        rend2.enabled = true;

        rend.sharedMaterial = materials[0];
        rend2.sharedMaterial = emote[0];
    }
    public void HoverEnter()
    {
        HOVER_SOUND.Play();
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

    private void OnMouseDown()
    {
        ChangeEmote();
    }

    private void OnMouseEnter()
    {
        HOVER_SOUND.Play();
        ChangeMaterials(1);
    }

    private void OnMouseExit()
    {
        ChangeMaterials(0);
    }
    public void TriggerSound()
    {
        ChangeEmote();
    }

    void ChangeEmote()
    {
        if (startCou)
        {
            StartCoroutine("UseVoice");
        }
        else
        {
            StopCoroutine("UseVoice");
        }
        startCou = !startCou;
    }

    IEnumerator UseVoice()
    {
        if (current == voices.Length)
            current = 0;
            rend2.sharedMaterial = emote[1];
            voices[current].Play();
            current++;
            yield return new WaitForSeconds(4f);
            rend2.sharedMaterial = emote[0];
    }
}
