using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    public InputActionProperty Trigger;

    [SerializeField] TextMeshProUGUI txt_Dialogue;
    [SerializeField] TextMeshProUGUI txt_Name;

    Dialogue[] dialogues;
    public GameObject waterGun;

    public GameObject WatchInfo;
    public GameObject WatchCall;

    bool isDialogue = false;    // 대화중일 경우 true
    bool isNext = false;    // 특정 키 입력 대기

    int lineCount = 0;  // 대화 카운트
    int contextCount = 0;   // 대사 카운트

    void Update()
    {
        if (isDialogue)
        {
            if(isNext)
            {
                if (Trigger.action.WasPressedThisFrame())
                {
                    isNext = false;
                    txt_Dialogue.text = "";
                    if(++contextCount < dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(TypeWriter());
                    }else{
                        contextCount = 0;
                        if (++lineCount < dialogues.Length) {
                            StartCoroutine(TypeWriter());
                        }else
                        {
                            EndDialogue();
                        }
                    }
                }
            }
        }
    }

    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        isDialogue = true;
        txt_Dialogue.text = "";
        txt_Name.text = "";
        dialogues = p_dialogues;

        StartCoroutine(TypeWriter());
    }

    void EndDialogue()
    {
        SettingUI(false);
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;
    }

    IEnumerator TypeWriter()
    {
        SettingUI(true);

        // '를 ,로
        string t_ReplaceText1 = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText1 = t_ReplaceText1.Replace("'", ",");
        txt_Dialogue.text = t_ReplaceText1;

        // 물음표를 ???로
        string t_ReplaceText2 = dialogues[lineCount].name;
        t_ReplaceText2 = t_ReplaceText2.Replace("물음표", "???");
        txt_Name.text = t_ReplaceText2;

        isNext = true;
        yield return null;
    }

    void SettingUI(bool p_flag)
    {
        Canvas.SetActive(p_flag);
        WatchInfo.SetActive(!p_flag);
        WatchCall.SetActive(p_flag);
    }
}
