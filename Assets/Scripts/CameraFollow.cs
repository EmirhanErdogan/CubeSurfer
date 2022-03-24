using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private Vector3 Distance;
    private void Start()
    {
        Distance = transform.position - Player.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = Player.transform.position + Distance;
        Debug.Log(PlayerPrefs.GetInt("Gem"));
        
    }
}
