using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCAI : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] public Transform playerTransform;
    public LayerMask ground, player;

    public Vector3 destinationPoint; 
    private bool destinationPointSet;
    public float walkPointRange;
    public bool alreadyAttack;
    public GameObject sphere;
    public float timeBetweenAttack;


    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    [SerializeField]
    Animator animator;
    public bool saldiriyiKes;

    float distanceToPlayer;
    LiveScript liveScript;
   Vector3 VampireTransform =  new Vector3(90, 0, 0);
    private void Start()
    {
        animator = GetComponent<Animator>();
        saldiriyiKes = true;
        Object.FindObjectOfType<LiveScript>();
    }


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, player);

        DistanceController();

        if (playerInSightRange == false && playerInAttackRange == false) EtrafindaGez();
        

        if (playerInSightRange == true && playerInAttackRange == false) KarakteriKovala();


        if (playerInSightRange == true && playerInAttackRange == true) KaraktereSaldir();

        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
    }

   public void EtrafindaGez()
    {
        if (destinationPointSet == false && saldiriyiKes == true)
        {

            SearchWalkPoint();

        }

        if(saldiriyiKes == true && destinationPointSet == true)
        {

            agent.SetDestination(destinationPoint);
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", false);
        }

        Vector3 distanceToDestinationPoint = transform.position - destinationPoint;

        if (distanceToDestinationPoint.magnitude < 1)
        {

            destinationPointSet = false; 

        }

    }

    void SearchWalkPoint()
    {

        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        destinationPoint = new Vector3(transform.position.x + randomX, transform.position.y,
            transform.position.z + randomZ);

        if (Physics.Raycast(destinationPoint, -transform.up, 2f, ground))
        {
            destinationPointSet = true;
           
        }
    }

    void KarakteriKovala()
    {
        if(saldiriyiKes == true)
        {
            agent.SetDestination(playerTransform.position);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", false);
        }

    }

  public void KaraktereSaldir()
    {
        agent.SetDestination(transform.position);

        if(saldiriyiKes == true)
        {

            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", true);
            animator.SetBool("isDead", false);
        }

        if (alreadyAttack == false && saldiriyiKes == true)
        {
            alreadyAttack = true;
            transform.LookAt(playerTransform);
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    void DistanceController()
    {
            if (distanceToPlayer <= 2)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttacking", true);
            }
            else
            {
                animator.SetBool("isAttacking", true);
                if (!playerInSightRange && !playerInAttackRange)
                {
                    animator.SetBool("isRunning", true);
                }
                else if (!playerInSightRange && playerInAttackRange)
                {
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isWalking", true);
                }
            }
       
    }

    void ResetAttack()
    {

        alreadyAttack = false;
    }


    public void Death()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isDead", true);
    }
}
