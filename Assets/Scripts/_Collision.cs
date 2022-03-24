using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!CubeCollect.Instance.cubes.Contains(other.gameObject))
        {
            if (other.gameObject.tag.Equals("Collectable"))
            {
                CubeCollect.Instance.CollectCube(other, CubeCollect.Instance.cubes.Count - 1);
            }
        }
        if (other.gameObject.tag.Equals("Obstacle"))
        {
            CubeCollect.Instance.ReleaseCube(this.gameObject);
        }

    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Obstacle"))
        {
            StartCoroutine(CubeCollect.Instance._sortCubes());
        }
    }
}
