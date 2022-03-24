using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollect : MonoBehaviour
{
    public static CubeCollect Instance;
    public List<GameObject> cubes;
    private Vector3 cubeNewPos;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider Other)
    {
       


    }
    public void CollectCube(Collider Cube, int index)
    {
        if (Cube.gameObject.tag.Equals("Collected")) return;

        Cube.gameObject.tag = "Collected";
        for (int i = 0; i < cubes.Count; i++)
        {
            cubeNewPos = cubes[i].transform.localPosition;
            cubeNewPos.y += cubes[i].transform.localScale.y;
            cubes[i].transform.localPosition = cubeNewPos;
        }
        Cube.gameObject.transform.parent = transform;
        Cube.transform.localPosition = new Vector3(cubes[index].transform.localPosition.x, Cube.transform.localPosition.y, cubes[index].transform.localPosition.z);
        Cube.GetComponent<Collider>().isTrigger = false;
        Cube.gameObject.AddComponent<Collision>();
        Cube.gameObject.AddComponent<Rigidbody>();
        cubes.Add(Cube.gameObject);


        //Pancake.GetComponent<Rigidbody>().isKinematic = false;
        //Pancake.GetComponent<Rigidbody>().useGravity = false;

    }
    private void ReleaseCube()
    {

    }


}
