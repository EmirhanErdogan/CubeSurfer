using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollect : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubes;
    private Vector3 cubeNewPos;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        CollectCube(other, cubes.Count - 1);
    }
    private void CollectCube(Collider Cube,int index)
    {
        if (Cube.gameObject.tag.Equals("Collectable")) return;
       
        if (Cube.gameObject.tag.Equals("Collectable"))
        {
            cubes.Add(Cube.gameObject);
            Cube.gameObject.transform.parent = transform;
            cubeNewPos = cubes[index].transform.localPosition;
            cubeNewPos.y += cubes[0].transform.localScale.y;
            Cube.transform.localPosition = cubeNewPos;
            //Pancake.GetComponent<Rigidbody>().isKinematic = false;
            //Pancake.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    private void ReleaseCube()
    {

    }


}
