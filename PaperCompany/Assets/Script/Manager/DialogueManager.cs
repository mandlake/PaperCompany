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

    bool isDialogue = false;    // ��ȭ���� ��� true
    bool isNext = false;    // Ư�� Ű �Է� ���

    int lineCount = 0;  // ��ȭ ī��Ʈ
    int contextCount = 0;   // ��� ī��Ʈ

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

        // '�� ,��
        string t_ReplaceText1 = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText1 = t_ReplaceText1.Replace("'", ",");
        txt_Dialogue.text = t_ReplaceText1;

        // ����ǥ�� ???��
        string t_ReplaceText2 = dialogues[lineCount].name;
        t_ReplaceText2 = t_ReplaceText2.Replace("����ǥ", "???");
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
