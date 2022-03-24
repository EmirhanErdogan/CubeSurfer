using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float playerBorder = 5.5f;
    private Touch Touch => Input.GetTouch(0);
    private Vector3 Pos
    {
        get => transform.position;
        set => transform.position = value;
    }
    private Vector3 movedPos;
    private void FixedUpdate()
    {
        FixedUpdateInit();
    }
    private void FixedUpdateInit()
    {
        PlayerVerticalMovement();
        PlayerHorizantalMovement();
        SetBorder();
    }
    private void PlayerVerticalMovement()
    {
        transform.Translate(new Vector3(0, 0, verticalSpeed * Time.deltaTime));
    }
    private void PlayerHorizantalMovement()
    {
        if (Input.touchCount <= 0) return;

        if (Touch.phase == TouchPhase.Moved)
        {
            movedPos = new Vector3(Pos.x + Touch.deltaPosition.x * (Time.fixedDeltaTime * horizontalSpeed), Pos.y, Pos.z);
            Pos = movedPos;
        }
    }
    private void SetBorder()
    {
        if (Pos.x < -playerBorder)
        {
            Pos = new Vector3(-playerBorder, Pos.y, Pos.z);
        }
        if (Pos.x > playerBorder)
        {
            Pos = new Vector3(playerBorder, Pos.y, Pos.z);
        }
    }






}