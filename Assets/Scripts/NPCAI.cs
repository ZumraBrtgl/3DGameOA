using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class NPCAI : MonoBehaviour
{
    // [SerializeField] private GameObject destinationPoint;

    // private NavMeshAgent _agent;

    // void Start()
    // {
    //     _agent = GetComponent<NavMeshAgent>();
    // }

    // void Update()
    //  {
    //     _agent.SetDestination(destinationPoint.transform.position);
    //  }

   
    public NavMeshAgent _agent;
    [SerializeField] Transform _player; // þimdi bizim karakterimizi takip etmesini istiyoruz.
    // Bu sefer layerlarla agentlarýn hangisini takip edip etmeyeeceðini anlamasýný saðlayacaðýz.
    public LayerMask ground, player;

    public Vector3 destinationPoint;
    private bool destinationPointSet;
    public float walkPointRange; // hareket edebileceðim mesafe

    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    public GameObject sphere;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        
        _agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, player);

        // Patrol / Chase / Attack

        if (!playerInSightRange && !playerInAttackRange) Patroling(); // bu birinci state
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    void Patroling()
    {
        if (!destinationPointSet)
        {
            SearchWalkPoint();
        }

        if (destinationPointSet)
        {
            _agent.SetDestination(destinationPoint);
        }

        Vector3 distanceToDestinationPoint = transform.position - destinationPoint;
        if (distanceToDestinationPoint.magnitude < 1.0f)
        {
            destinationPointSet = false;
        }
    }

    void SearchWalkPoint()
    {
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        destinationPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast ( destinationPoint, -transform.up, 2.0f, ground))
        {
            destinationPointSet = true;
        }
    }

    void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }

    void AttackPlayer()
    {
        _agent.SetDestination(transform.position);

        transform.LookAt(_player);
        if (!alreadyAttacked)
        {
            //logic
            Rigidbody rb = Instantiate(sphere, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 25f, ForceMode.Impulse); // ileri
            rb.AddForce(transform.up * 7f, ForceMode.Impulse); // yukarý

            StartCoroutine(ChangeTag(rb.gameObject));
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    IEnumerator ChangeTag(GameObject gameObject) // Bu fonksiyonda yaptýðýmýz þey spherein tagini deðiþtirmek.
    {
        yield return new WaitForSeconds(2);
        gameObject.tag = "Respawn"; 
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }


}
