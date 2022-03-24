using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!CubeCollect.Instance.cubes.Contains(other.gameObject))
        {
            if (other.gameObject.tag == "Collectable")
            {
               CubeCollect.Instance.CollectCube(other, CubeCollect.Instance.cubes.Count - 1);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        

    }
}
