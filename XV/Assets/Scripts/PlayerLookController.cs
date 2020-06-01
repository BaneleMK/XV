using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLookController : CharacterFunctions
{
    public bool firstpersoncam = true;
    public Camera firstPerson;
    public Camera thirdPerson;
    public Camera currentcam;
    public bool focusmode;
    public GameObject focusUI;
    private Text gt;
    private bool entertext;
    public float objectSpeed = 1f;

    private void Start()
    {
        thirdPerson.enabled = false;
        currentcam = firstPerson;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        if (focus != null)
        {
            if (focusmode)
            {
                if (!entertext)
                {
                    float horizontalInput = Input.GetAxis("Horizontal");
                    float verticalInput = Input.GetAxis("Vertical");

                    //update the position
                    focus.gameObject.transform.position = focus.gameObject.transform.position + new Vector3(horizontalInput * objectSpeed * Time.deltaTime, 0, verticalInput * objectSpeed * Time.deltaTime);

                    if (Input.GetKeyDown("j"))
                    {
                        focus.gameObject.transform.Rotate(0, 90f, 0, Space.Self);
                    }
                    else if (Input.GetKeyDown("l"))
                    {
                        focus.gameObject.transform.Rotate(0, -90f, 0, Space.Self);
                    }
                    
                    if (Input.GetKeyDown("o"))
                    {
                        focus.destroyObject();
                        RemoveFocus();
                    }

                    if (Input.GetKeyDown("u"))
                    {
                        focusMaterial(focus.gameObject, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
                    }

                    if (Input.GetKeyDown("n"))
                    {
                        gt = focusUI.transform.GetChild(0).GetComponent<Text>();
                        gt.text = "";
                        entertext = true;
                    }

                }
                else
                {
                    foreach (char c in Input.inputString)
                    {
                        if (c == '\b')
                        {
                            if (gt.text.Length != 0)
                            {
                                gt.text = gt.text.Substring(0, gt.text.Length - 1);
                            }
                        }
                        else if ((c == '\n') || (c == '\r'))
                        {
                            entertext = false;
                            focus.gameObject.name = gt.text;
                            focusUI.transform.GetChild(0).GetComponent<Text>().text = "Name: " + focus.gameObject.name;
                        }
                        else
                        {
                            gt.text += c;
                        }
                    }

                }
            }
            
        } else {
            if (Input.GetKeyDown("m"))
            {
                importModel();
            }

            //1st to 3rd person
            if (Input.GetKeyDown("c"))
            {
                if (firstpersoncam == true)
                {
                    firstpersoncam = false;
                    firstPerson.enabled = false;
                    thirdPerson.enabled = true;
                    currentcam = thirdPerson;
                }
                else
                {
                    firstpersoncam = true;
                    firstPerson.enabled = true;
                    thirdPerson.enabled = false;
                    currentcam = firstPerson;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = currentcam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Debug.Log("found interactable");
                    SetFocus(interactable);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RemoveFocus();
        }
    }

    void importModel()
    {

    }

    

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        focusmode = true;
        focusUI.SetActive(true);
        focus.OnFocused(transform);
        focusUI.transform.GetChild(0).GetComponent<Text>().text = "Name: " + focus.name;
    }

    void RemoveFocus()
    {
        focus.OnDefocused();
        focusmode = false;
        focusUI.SetActive(false);
        focus = null;
    }
}
