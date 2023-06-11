using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();  // ��� ����Ʈ ����
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);    // CSV ���� ������

        string[] data = csvData.text.Split(new char[] { '\n' });    // ���ͷ� ��� ����
        
        for(int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });

            Dialogue dialogue = new Dialogue(); // ��� ����Ʈ ����

            dialogue.name = row[1];
            List<string> contextList = new List<string>();

            do
            {
                contextList.Add(row[2]);
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                } else
                {
                    break;
                }
            } while (row[0].ToString() == "");

            dialogue.contexts = contextList.ToArray();

            dialogueList.Add(dialogue);
        }

        return dialogueList.ToArray();
    }
}
