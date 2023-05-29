using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BridgeController : MonoBehaviour
{
    [SerializeField] Transform targetTransform; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>(); 
        if (agent != null)
        {
            agent.transform.position = this.transform.position;
        }
    }
}
