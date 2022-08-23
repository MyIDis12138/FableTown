using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyStates{GUARD, PATROL, CHASE, DEAD};

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private EnemyStates states;
    private NavMeshAgent agent;
    private Animator anima;
    private CharacterStates chastate;



    [Header("Basic Settings")]
    public float sightRadius;

    private float speed;

    public bool isGuard;

    public float lookAtTime;

    private float remainLookatTime;

    private GameObject attackTarget;

    private float LastAttackTime;

    [Header("Patrol State")]
    public float PatrolRange;
    private Vector3 WayPoint;
    private Vector3 GuradPos;
    private Quaternion GuradRot;



    // for animation
    bool isWalk;
    bool isChase;
    bool isFollow;
    bool isDie;


    void Awake()
    {
        anima = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        chastate = GetComponent<CharacterStates>();
        chastate.currentHealth = chastate.maxHealth;
        agent.enabled = true;
        speed = agent.speed;
        GuradPos = transform.position;
        GuradRot = transform.rotation;
        remainLookatTime = lookAtTime;
        LastAttackTime = 0f;

    }

    void Start()
    {
        //chastate.currentHealth = 0;

        if (isGuard)
        {
            states = EnemyStates.GUARD;
        }
        else
        {
            states = EnemyStates.PATROL;
            GetWayPoint();
        }
    }

    void Update()
    {
        //Debug.Log(chastate.currentHealth);  
        if (chastate.currentHealth <= 0)
        {
            isDie = true;
        }
        else
        {
            isDie = false;
        }
        SwitchStates();
        SwitchAnimation();
        LastAttackTime -= Time.deltaTime;

    }

    void SwitchAnimation()
    {

        anima.SetBool("Walk", isWalk);
        anima.SetBool("Chase", isChase);
        anima.SetBool("Follow", isFollow);
        anima.SetBool("Critical", chastate.isCritical);
        anima.SetBool("Death", isDie);

    }

    void SwitchStates()
    {

        if (FoundPlayer())
        {
            states = EnemyStates.CHASE;
        }
        if (isDie)
        {
            states = EnemyStates.DEAD;
        }
        switch (states)
        {
            case EnemyStates.GUARD:
                isWalk = false;
                agent.isStopped = true;

                if(transform.position!= GuradPos)
                {
                    isWalk = true;
                    agent.isStopped = false;
                    agent.destination = attackTarget.transform.position;

                    if(Vector3.SqrMagnitude(GuradPos - transform.position) <= agent.stoppingDistance)
                    {
                        isWalk = false;
                        transform.rotation = Quaternion.Lerp(transform.rotation, GuradRot,0.01f);
                    }
                    
                }

                break;
            case EnemyStates.PATROL:

                isChase = false;
                agent.speed = speed * 0.5f;

                // stop when achieved new point
                if (Vector3.Distance(WayPoint, transform.position) <= agent.stoppingDistance)
                {
                    isWalk = false;
                    if (remainLookatTime > 0)
                        remainLookatTime -= Time.deltaTime;
                    GetWayPoint();
                }
                else
                {
                    isWalk = true;
                    agent.destination = WayPoint;
                }

                break;
            case EnemyStates.CHASE:
                isWalk = false; 
                isChase = true;

                if (!FoundPlayer())
                {
                    isFollow = false;

                    // stop and back to perivous state
                    if (remainLookatTime > 0)
                    {
                        agent.destination = transform.position;
                        remainLookatTime -= Time.deltaTime;
                    }
                    else if(isGuard)
                    {
                        states = EnemyStates.GUARD;
                    }
                    else
                    {
                        states = EnemyStates.PATROL;
                    }
                }
                else
                {
                    if (TargetInAttackRange())
                    {
                        isFollow = false;
                        agent.isStopped = true;
                        //Debug.Log("Find and attack");
                        
                        if (LastAttackTime < 0)
                        {
                            LastAttackTime = chastate.characterAttack.coolDown;
                            chastate.isCritical = Random.value < chastate.characterAttack.criticalChance;
                            Attack();
                        }
                    }
                    else
                    {
                        isFollow = true;
                        agent.isStopped = false;
                        agent.destination = attackTarget.transform.position;
                       // Debug.Log(Vector3.Distance(transform.position, attackTarget.transform.position));
                    }
                }


                

                break;
            case EnemyStates.DEAD:
                agent.enabled = false;
                Destroy(gameObject,2f);
                break;
        }
    }

    void Attack()
    {
        transform.LookAt(attackTarget.transform);
        if (TargetInAttackRange())
        {
            anima.SetTrigger("Attack");
        }
        if (TargetInSkillRange())
        {
            anima.SetTrigger("Skill");
        }
    }

    bool FoundPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, sightRadius);
        foreach(var target in colliders)
        {
            if (target.CompareTag("Player"))
            {
                attackTarget = target.gameObject;
                return true;
            }
        }
        attackTarget = null;
        return false;
    }

    bool TargetInAttackRange()
    {
        if(attackTarget != null)
        {
            return (Vector3.Distance(transform.position, attackTarget.transform.position) <= chastate.characterAttack.attackRange);
        }
        else
        {
            return false;
        }
    }

    bool TargetInSkillRange()
    {
        if (attackTarget != null)
        {
            return Vector3.Distance(transform.position, attackTarget.transform.position) <= chastate.characterAttack.skillRange;
        }
        else
        {
            return false;
        }
    }


    void GetWayPoint()
    {
        remainLookatTime = lookAtTime;

        float randomX = Random.Range(-PatrolRange, PatrolRange);
        float randomZ = Random.Range(-PatrolRange, PatrolRange);

        Vector3 randomPoint = new Vector3(GuradPos.x + randomX, transform.position.y, GuradPos.z + randomZ);

        NavMeshHit hit;
        WayPoint = NavMesh.SamplePosition(randomPoint,out hit, PatrolRange,1)? hit.position : randomPoint;    // stop at the point when the position is not walkable
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRadius);
    }

    private void Hit()
    {
        if(attackTarget!= null)
        {
            var targetStats = attackTarget.GetComponent<CharacterStates>();
            targetStats.TakeDamage(chastate, targetStats);
        }
    }

}
