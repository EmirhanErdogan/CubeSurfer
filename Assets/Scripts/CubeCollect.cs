using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeCollect : MonoBehaviour
{
    public static CubeCollect Instance;
    public List<GameObject> cubes;
    private Vector3 cubeNewPos;
    [SerializeField]private Text gemText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        PlayerPrefs.SetInt("Gem", PlayerPrefs.GetInt("Gem"));
    }
    public void CollectCube(Collider Cube, int index)
    {
        if (Cube.gameObject.tag.Equals("Collected")) return;

        Cube.gameObject.tag = "Collected";
        transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("ÝsJump", true);
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
        Cube.GetComponent<Rigidbody>().mass = 100;
        Cube.GetComponent<Rigidbody>().isKinematic = true;
        cubes.Add(Cube.gameObject);

    }
    public void ReleaseCube(GameObject releaseCube)
    {
        if (releaseCube.tag.Equals("Player")) return;

        releaseCube.transform.parent = null;
        CubeCollect.Instance.cubes.Remove(releaseCube);
        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].GetComponent<Rigidbody>().isKinematic = false;
            cubes[i].GetComponent<Rigidbody>().AddForce(0, -999f, 0,ForceMode.Force);
        }
    }
    public IEnumerator _sortCubes()
    {
        yield return new WaitForSeconds(1.5f);
        Vector3 SortPos = cubes[0].transform.localPosition;
        int yPos = 0;
        for (int i = cubes.Count-1; i >= 0; i--)
        {
            Debug.Log("asdasd");
            cubes[i].transform.localPosition = new Vector3(SortPos.x,yPos , SortPos.z);
            cubes[i].GetComponent<Rigidbody>().isKinematic = true;
            cubes[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            yPos += 3;
        }

    }
    public void CollectGem(Collider obj)
    {
        obj.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Gem", PlayerPrefs.GetInt("Gem") + 1);
        gemText.text = string.Format("X {0}",PlayerPrefs.GetInt("Gem"));
    }
    //TODO
    //TRAÝL KAPANMASI LEVEL SONU ÇARPMA YAP
    //DÜÞTÜKTEN SONRA PLAYER ANÝMASYONU
    //ZIPLADIÐINDA PARTÝCLE AÇ KAPAT

}
