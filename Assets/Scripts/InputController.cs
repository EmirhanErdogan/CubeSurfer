using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    private DynamicJoystick Joystick;
    public float zPosition = 0;
    private void Start()
    {
        Joystick = GetComponent<DynamicJoystick>();
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void LateUpdate()
    {
        LateUpdateInit();
    }
    private void LateUpdateInit()
    {
        //Joystick Input
        //1 to right -1 to left 0 to stop
        if (Joystick.Horizontal > 0.5f)
        {
            zPosition = -1;
        }
        else if (Joystick.Horizontal < -0.5f)
        {
            zPosition = 1;
        }
        else
        {
            zPosition = 0;
        }
    }
}
