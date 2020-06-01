using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(NavMeshAgent))]
public class WorkerController : CharacterFunctions
{
    public Text workerTerm;
    public Camera cam;
    public LayerMask movementMask;
    public float WorkerSightRadar = 10f;
    private PlayerMotor motor;
    private NavMeshAgent agent;

    private bool agentmovement;

    public GameObject reference1_a = null;
    public GameObject reference1_b = null;
    public string task1 = null;
    public GameObject reference2_a = null;
    public GameObject reference2_b = null;
    public string task2 = null;
    public GameObject reference3_a = null;
    public GameObject reference3_b = null;
    public string task3 = null;
    public GameObject reference4_a = null;
    public GameObject reference4_b = null;
    public string task4 = null;
    public GameObject reference5_a = null;
    public GameObject reference5_b = null;
    public string task5 = null;

    private float oldspeed;

    // Start is called before the first frame update
    void Start()
    {
        oldspeed = GameTaskMananger.gameSpeed;
        motor = GetComponent<PlayerMotor>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 1f;
    }
    
    public void starWorking()
    {
        StartCoroutine(TaskMananger());
    }

    private void Update()
    {
        if (oldspeed != GameTaskMananger.gameSpeed)
        {
            reference1_a.GetComponent<NavMeshAgent>().speed = reference1_a.GetComponent<NavMeshAgent>().speed * GameTaskMananger.gameSpeed;
            agent.speed = agent.speed * GameTaskMananger.gameSpeed;
        }
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
        agent.speed = agent.speed * GameTaskMananger.gameSpeed;
        reference1_a.GetComponent<NavMeshAgent>().enabled = true;
        reference1_a.GetComponent<NavMeshAgent>().speed = reference1_a.GetComponent<NavMeshAgent>().speed * GameTaskMananger.gameSpeed;

        if (reference1_a && task1 != null)
        {
            StartCoroutine(doTask(reference1_a, reference1_b, task1));
        }
        yield return new WaitForSeconds(4 / GameTaskMananger.gameSpeed);
        if (reference2_a && task2 != null)
        {
            StartCoroutine(doTask(reference2_a, reference2_b, task2));
        }
        yield return new WaitForSeconds(8 / GameTaskMananger.gameSpeed);
        if (reference3_a && task3 != null)
        {
            StartCoroutine(doTask(reference3_a, reference3_b, task3));
        }
        yield return new WaitForSeconds(12 / GameTaskMananger.gameSpeed);
        if (reference4_a && task4 != null)
        {
            StartCoroutine(doTask(reference4_a, reference4_b, task4));
        }
        yield return new WaitForSeconds(16 / GameTaskMananger.gameSpeed);
        if (reference5_a && task5 != null)
        {
            StartCoroutine(doTask(reference5_a, reference5_b, task5));
        }
    }

    IEnumerator doTask(GameObject reference_1, GameObject reference_2, string task)
    {
        // move to target
        reference_1.GetComponent<Interactable>().OnFocused(transform);
        float interactRanage = reference_1.GetComponent<Interactable>().radius;
        agent.SetDestination(reference_1.transform.position);

        // when in interacting range do task
        // move // changeMaterial // dropoff
        yield return new WaitForSeconds(4 / GameTaskMananger.gameSpeed);

        if (task.Equals("changeMat"))
        {
            workerTerm.text = "Changing Material";
            focusMaterial(reference_1.gameObject, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
            Debug.Log("JOB : " + task +" | Changed material :D");
        }
        else if (task.Equals("move"))
        {
            if (reference_2 != null)
            {
                workerTerm.text = "Moving object";
                yield return new WaitForSeconds(4 / GameTaskMananger.gameSpeed);
                //move with object 2
                reference_1.GetComponent<PlayerMotor>().FollowTarget(transform);
                Debug.Log("1JOB : " + task + " | Moving object");
                agent.SetDestination(reference_2.transform.position);

                //wait for the move
                Debug.Log("2JOB : " + task + " | at destination");
                yield return new WaitForSeconds(4 / GameTaskMananger.gameSpeed);

                //leave object                                                                                                        
                reference_1.GetComponent<PlayerMotor>().StopFollowTarget();
                reference_1.GetComponent<NavMeshAgent>().enabled = false;
                reference_1.transform.position = new Vector3(reference_2.transform.position.x, 1, reference_2.transform.position.z);
                Debug.Log("3JOB : " + task + " | Stoping following");
            }
        }
        else
        {
            workerTerm.text = "Doing nothing";
            Debug.Log("INVALID JOB : " + task);
        }
    }
}
