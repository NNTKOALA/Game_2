using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public static BrickManager Instance;

    [SerializeField] GameObject brickPrefab;
    [SerializeField] ObjectPool pool;

    private bool isSpawnedOn2Foor = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnAllBrick();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnAllBrick()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                //GameObject obj = Instantiate(brickPrefab);
                BrickController obj = pool.GetPooledObject();
                obj.transform.position = new Vector3(7f - i*2, 0f, 7f - j*2);
            }
        }
    }

    public void SpawnAllBrickFloor2()
    {
        if (!isSpawnedOn2Foor)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //GameObject obj = Instantiate(brickPrefab);
                    BrickController obj = pool.GetPooledObject();
                    obj.transform.position = new Vector3(7f - i * 2, 4.8f, 35f + j * 2);
                }
            }
            isSpawnedOn2Foor=true;
        }    
    }
}
