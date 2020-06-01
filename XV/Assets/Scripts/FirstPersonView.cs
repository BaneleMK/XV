using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonView : MonoBehaviour
{
    private bool movefoward;
    private bool moveback;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if (movefoward)
        {
            transform.position.Set(x + 1f, y, z);
        }

        if (moveback)
        {
            transform.position.Set(x - 1f, y, z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            movefoward = true;
        }
        else
        { 
            movefoward = false;
        }

        if (Input.GetKey("s"))
        {
            moveback = true;
        }
        else
        {
            moveback = false;
        }
    }
}
