using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Collision : MonoBehaviour
{
    [SerializeField]private float speed;

    private void OnTriggerEnter(Collider other)
    {
        if (!CubeCollect.Instance.cubes.Contains(other.gameObject))
        {
            if (other.gameObject.tag.Equals("Collectable"))
            {
                CubeCollect.Instance.CollectCube(other, CubeCollect.Instance.cubes.Count - 1);
            }
        }
        if (this.gameObject.tag.Equals("Player"))
        {
            if (other.gameObject.tag.Equals("Obstacle"))
            {
                Debug.Log("LOSE");
                CubeCollect.Instance.cubes[0].gameObject.transform.parent.GetComponent<PlayerMovement>().enabled = false;
            }
            return;
        }
        if (other.gameObject.tag.Equals("Obstacle"))
        {
            CubeCollect.Instance.ReleaseCube(this.gameObject);
            StartCoroutine(CubeCollect.Instance._sortCubes());
        }
        if (other.gameObject.tag.Equals("Gem"))
        {
            CubeCollect.Instance.CollectGem(other);
        }


    }
}
