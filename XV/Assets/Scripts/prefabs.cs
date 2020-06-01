using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class prefabs : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3_worker;
    private GameObject go;

    public void SpawnBox()
    {
        go = Instantiate(prefab1, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        go.AddComponent<BoxCollider>();
        go.AddComponent<NavMeshObstacle>();
        go.GetComponent<NavMeshObstacle>().carving = true;
        go.AddComponent<Interactable>();
    }

    public void SpawnTable()
    {
        go = Instantiate(prefab2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        go.AddComponent<BoxCollider>();
        go.AddComponent<NavMeshObstacle>();
        go.GetComponent<NavMeshObstacle>().carving = true;
        go.AddComponent<Interactable>();
    }

    public void SpawnWorker()
    {
        go = Instantiate(prefab3_worker, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    }


}
