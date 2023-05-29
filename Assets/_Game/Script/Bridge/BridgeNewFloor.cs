using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeNewFloor : MonoBehaviour
{
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
        if (other != null)
        {
            BrickManager.Instance.SpawnAllBrickFloor2();
            if (other.GetComponent<Bot>() != null)
            {
                other.GetComponent<Bot>().ChanggeDestination();
            }
        }
    }
}
