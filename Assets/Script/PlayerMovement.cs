using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 goright;
    Vector3 goleft;
    void Update()
    {
        goright = new Vector3(-5.5f, transform.position.y, transform.position.z);
        goleft = new Vector3(5.5f, transform.position.y, transform.position.z);
        if (InputController.Instance.zPosition == -1)//goleft2
        {
            transform.position = Vector3.Lerp(transform.position, goleft, 3 * Time.deltaTime);
        }
        else if (InputController.Instance.zPosition == 1)//goright-2
        {
            transform.position = Vector3.Lerp(transform.position, goright, 3 * Time.deltaTime);
        }
    }
}
