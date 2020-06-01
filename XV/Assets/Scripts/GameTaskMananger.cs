using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTaskMananger : MonoBehaviour
{
    public static float gameSpeed = 1f;

    public  void setSpeedHalf()
    {
        gameSpeed = .5f;
        Debug.Log("speed set to " + gameSpeed);
    }

    public  void setSpeedDouble()
    {
        gameSpeed = 2f;
        Debug.Log("speed set to " + gameSpeed);
    }

    public  void setSpeedNormal()
    {
        gameSpeed = 1f;
        Debug.Log("speed set to " + gameSpeed);
    }
}
