using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField]
    private Material[] emote;
    private Renderer rend;
    private int x;

    [SerializeField]
    private AudioSource[] voices;
    private int current = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = emote[0];
        InvokeRepeating("ChangeEmote", 0f, 15f);
    }


    void ChangeEmote()
    {
        StartCoroutine("UseVoice");
    }

    IEnumerator UseVoice()
    {
        for (int i = 0; i < voices.Length; i++)
        {
            rend.sharedMaterial = emote[i];
            voices[current].Play();
            current++;
            yield return new WaitForSeconds(4f);
        }
    }
}
