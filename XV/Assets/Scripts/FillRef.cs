using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillRef : MonoBehaviour
{
    private PlayerLookController PLC = FindObjectOfType<PlayerLookController>();
    public GUIText ref1_a;
    public GUIText ref1_b;
    bool addedfocus;
    // Start is called before the first frame update
    void Start()
    {
        addedfocus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PLC.focusmode && !addedfocus)
        {
            PLC.getFocus();
            addedfocus = true;
        } else if (PLC.focusmode && addedfocus)
        {
            addedfocus = false;
        }

    }
}
