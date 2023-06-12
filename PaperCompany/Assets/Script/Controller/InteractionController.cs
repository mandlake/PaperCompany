using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    DialogueManager theDM;
    AudioManager AM;
    public Button call;

    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
        AM.Play("ringtone");
        theDM = FindObjectOfType<DialogueManager>();
        call.onClick.AddListener(WaitClick);
    }

    void WaitClick()
    {
        call.enabled = false;
        AM.Stop("ringtone");
        theDM.ShowDialogue(GetComponent<InteractionEvent>().GetDialogue());
    }
}
