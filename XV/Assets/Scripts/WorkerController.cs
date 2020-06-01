using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(NavMeshAgent))]
public class WorkerController : CharacterFunctions
{
    public Camera cam;
    public LayerMask movementMask;
    public float WorkerSightRadar = 10f;
    private PlayerMotor motor;
    private NavMeshAgent agent;

    private bool agentmovement;

    public GameObject reference1;
    public string task1;
    public GameObject reference2;
    public string task2;
    public GameObject reference3;
    public string task3;
    public GameObject reference4;
    public string task4;
    public GameObject reference5;
    public string task5;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 1f;

        StartCoroutine(TaskMananger());
    }

    void SetFocus(Interactable newFocus)
    {
        if (focus != newFocus)
        {
            focus.OnDefocused();
            focus = newFocus;
        }
        focus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        focus.OnDefocused();
        focus = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, WorkerSightRadar);
    }

    IEnumerator TaskMananger()
    {

        if (reference1 && task1 != null)
        {
            StartCoroutine(doTask(reference1, task1));
            Debug.Log("Task 1 done");
            yield return new WaitForSeconds(4);
        }
        yield return new WaitForSeconds(4);
        if (reference2 && task2 != null)
        {
            StartCoroutine(doTask(reference2, task2));
            Debug.Log("Task 2 done");
            yield return new WaitForSeconds(4);
        }
        if (reference3 && task3 != null)
        {
            StartCoroutine(doTask(reference3, task3));
            Debug.Log("Task 3 done");
            yield return new WaitForSeconds(4);
        }
        if (reference4 && task4 != null)
        {
            StartCoroutine(doTask(reference4, task4));
            Debug.Log("Task 4 done");
            yield return new WaitForSeconds(4);
        }
        if (reference5 && task5 != null)
        {
            StartCoroutine(doTask(reference5, task5));
            Debug.Log("Task 5 done");
        }
    }

    IEnumerator doTask(GameObject reference, string task)
    {   
        // move to target
        
        
        reference.GetComponent<Interactable>().OnFocused(transform);
        float interactRanage = reference.GetComponent<Interactable>().radius;
        agent.SetDestination(reference.transform.position);

        Debug.Log(task + " DONE");

        // when in interacting range do task
        // pickup // changeMaterial // dropoff
        yield return new WaitForSeconds(4);

        if (task.Equals("changeMaterial")) {
            focusMaterial(reference.gameObject, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
            Debug.Log("JOB : " + task +" | Done :D");
        } else if (task.Equals("pickup")) {
            reference.GetComponent<PlayerMotor>().FollowTarget(transform);
            Debug.Log("JOB : " + task + " | Done :D");
        } else if (task.Equals("dropoff")) {
            reference.GetComponent<PlayerMotor>().StopFollowTarget();
            Debug.Log("JOB : " + task + " | Done :D");
        }
        else {
            Debug.Log("INVALID JOB : " + task);
        }

    }
}
