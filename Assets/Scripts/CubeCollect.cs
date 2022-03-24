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
        Cube.gameObject.AddComponent<_Collision>();
        Cube.gameObject.AddComponent<Rigidbody>();
        Cube.GetComponent<Rigidbody>().mass = 3.5f;
        cubes.Add(Cube.gameObject);

    }
    public void ReleaseCube(GameObject releaseCube)
    {
        releaseCube.transform.parent = null;
        CubeCollect.Instance.cubes.Remove(releaseCube);
    }
    public IEnumerator _sortCubes()
    {
        yield return new WaitForSeconds(1.2f);
        Vector3 SortPos = cubes[0].transform.localPosition;
        for (int i = 1; i < cubes.Count; i++)
        {
            cubes[i].transform.localPosition = new Vector3(SortPos.x, cubes[i].transform.localPosition.y, SortPos.z);
        }

    }

}
