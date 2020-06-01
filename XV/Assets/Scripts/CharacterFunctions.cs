using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFunctions : MonoBehaviour
{
    protected Interactable focus;

    protected void focusMaterial(GameObject focus, Color color)
    {
        if (focus.transform.childCount > 0)
        {
            for (int i = 0; i < focus.transform.childCount; i++)
            {
                focusMaterial(focus.transform.GetChild(i).gameObject, color);
            }
        }
        else
        {
            try
            {
                // statements causing exception
                focus.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
            catch (System.NullReferenceException e1)
            {
                // error handling code
                Debug.Log("tried : " + e1);
            }
        }
    }
}
