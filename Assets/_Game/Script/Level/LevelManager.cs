using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public List<GameObject> levelPrefab;
    public int currentLevel;
    private GameObject currentLevelInstance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;
        currentLevelInstance = Instantiate(levelPrefab[currentLevel]);
    }

    public void NextLevel()
    {
        currentLevel++;

        Destroy(currentLevelInstance);

        currentLevelInstance = Instantiate(levelPrefab[currentLevel]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
