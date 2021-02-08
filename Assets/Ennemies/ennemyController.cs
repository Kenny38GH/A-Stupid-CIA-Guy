using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public GameObject player;
    
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
      float distance = Vector3.Distance(player.transform.position, transform.position);
      
      if (distance <= lookRadius)
        {
        agent.SetDestination(player.transform.position);

        if (distance <= agent.stoppingDistance)

        {
                // faire face au jouer
                FaceTarget();
                //attaquer

        }

        }
    }
    void FaceTarget()
        {

        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        

        }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , lookRadius);
        
    }
}