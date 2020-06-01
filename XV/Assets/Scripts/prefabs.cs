using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class prefabs : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    private GameObject go;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            go = Instantiate(prefab1, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go.AddComponent<BoxCollider>();
            go.AddComponent<NavMeshObstacle>();
            go.GetComponent<NavMeshObstacle>().carving = true;
            go.AddComponent<Interactable>();
        }
        if (Input.GetKeyDown("n"))
        {
            go = Instantiate(prefab2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go.AddComponent<BoxCollider>();
            go.AddComponent<NavMeshObstacle>();
            go.GetComponent<NavMeshObstacle>().carving = true;
            go.AddComponent<Interactable>();
        }
    }
}
