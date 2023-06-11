using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    DialogueManager theDM;
    public Button call;

    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        call.onClick.AddListener(WaitClick);
    }

    void WaitClick()
    {
        call.enabled = false;
        theDM.ShowDialogue(GetComponent<InteractionEvent>().GetDialogue());
    }
}
