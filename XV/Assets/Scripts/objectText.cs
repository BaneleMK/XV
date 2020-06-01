using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class objectText : MonoBehaviour
{
    public Text gt;

    void Start()
    {
        gt = GetComponent<Text>();
    }
    private void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (gt.text.Length != 0)
                {
                    gt.text = gt.text.Substring(0, gt.text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                break;
            }
            else
            {
                gt.text += c;
            }
        }
    }
}
