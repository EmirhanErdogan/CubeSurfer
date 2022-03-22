using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    private DynamicJoystick joystick;
    public float xPosition = 0;
    private void Start()
    {
        joystick = GetComponent<DynamicJoystick>();
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
        if (joystick.Horizontal > 0.5f)
        {
            xPosition = -1;
        }
        else if (joystick.Horizontal < -0.5f)
        {
            xPosition = 1;
        }
        else
        {
            xPosition = 0;
        }
    }
}
