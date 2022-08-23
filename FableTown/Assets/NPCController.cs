using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class NPCController : MonoBehaviour
{

    private Animator Anima;
    private NavMeshAgent agent;
    private bool iswalk;
    private bool istriggerwalk;
    private bool isTriggerTalk;
    private int CurrentDialog;  
    private Transform CurrentDes;
    private bool abletoTalk;

    public Transform Player;
    public float Sightrange;
    public Transform[] Destiantions;
    public float DialogDistance;
    public KeyCode DialogKey = KeyCode.E;
    public GameObject[] Dialogs;
    public GameObject Tips;
    private void Awake()
    {
        Anima = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        CurrentDialog = 0;
        iswalk = false;
        istriggerwalk = false;
        abletoTalk = true;
        isTriggerTalk = false;
    }
    private void FixedUpdate()
    {
        if (isPlayerTalk()&&abletoTalk)
        {
            abletoTalk = false;
            if (CurrentDialog <= Dialogs.Length)
            {
                Dialogs[CurrentDialog].active = true;
                isTriggerTalk = true;
            }
            else
            {
                abletoTalk = false;
                isTriggerTalk = false;
            }
        }
        if (isTriggerTalk && !Dialogs[CurrentDialog].active)
        {
            isTriggerTalk = false;
            ChangeDestination();
            SetWalk();
        }
        WalkToCurrentDestination();

        //if (isPlayerTalk())
        //{
        //    Debug.Log("Talk");
        //}
        //else
        //{
        //    Debug.Log("False");
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Sightrange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, DialogDistance);
    }

    bool isPlayerNear()
    {
        return Vector3.Distance(Player.position, transform.position) <= Sightrange;
    }

    bool isPlayerTalk()
    {
        if (isPlayerNear())
        {
            if((Vector3.Distance(Player.position, transform.position) <= DialogDistance)&& abletoTalk){
                Tips.active = true;
            }
            else
            {
                Tips.active = false;
            }
        }


        return (Vector3.Distance(Player.position, transform.position) <= DialogDistance)&&Input.GetKeyDown(DialogKey)&&abletoTalk;
    }

    public void SetWalk()
    {
        istriggerwalk = true;
    }

    private void StopAtDes()
    {
        if (Vector3.Distance(transform.position, CurrentDes.position) < 2)
        {
            agent.isStopped = true;
            iswalk = false;
            transform.LookAt(Player.transform.position);
            istriggerwalk = false;
        }

    }

    public void TalkWithPlayer()
    {
        transform.LookAt(Player.transform.position);
    }

    void ChangeDestination()
    {
        CurrentDialog++;
        if (CurrentDialog > Destiantions.Length)
        {
            CurrentDialog = Destiantions.Length;
        }
        CurrentDes = Destiantions[CurrentDialog];
    }

    void WalkToCurrentDestination()
    {
        if (istriggerwalk && !isPlayerNear())
        {
            iswalk = false;
            agent.isStopped = true;
            transform.LookAt(Player.position);
        }
        else if (istriggerwalk && isPlayerNear())
        {
            iswalk = true;
            agent.isStopped = false;
            agent.destination = CurrentDes.position;
        }
        else
        {
            agent.isStopped = true;
            transform.LookAt(Player.position);
        }
        if (istriggerwalk)
        {
            abletoTalk = false;
        }
        else if (CurrentDialog<Dialogs.Length&&!Dialogs[CurrentDialog].active)
        {
            abletoTalk = true;
        }
        else if(CurrentDialog > Dialogs.Length)
        {
            abletoTalk = false;
        }
        StopAtDes();
        Anima.SetBool("Walk", iswalk);
    }


    //public Vector3 Position
    //{
    //    get
    //    {
    //        return Vector3.zero;
    //    }
    //    set
    //    {
    //        Walkto(Position);
    //        Position = value;
    //    }
    //}
    //public void Walkto(Vector3 Position)
    //{
    //    Debug.Log("Function called");
    //    StartCoroutine(WalktoDes(Position));
    //}

    //IEnumerator WalktoDes(Vector3 Position)
    //{
    //    Debug.Log(Vector3.Distance(transform.position, Position));
    //    if (Vector3.Distance(transform.position, Position) > 1)
    //    {
    //        Debug.Log("Walking");
    //        Anima.SetBool("Walk", iswalk);
    //        agent.isStopped = true;
    //        agent.destination = Position;
    //        yield return null;
    //    }
    //    else
    //    {
    //        agent.isStopped = true;
    //        yield break;
    //    }
    //}

}
