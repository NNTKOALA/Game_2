using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStage  : MonoBehaviour
{
    public GameObject endpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        Bot bot = other.GetComponent<Bot>();

        if (player != null)
        {
            player.ResetPlayerPosition();
            player.RemoveAllBrick();
            LevelManager.instance.NextLevel();
            
        }

        if(bot != null)
        {
            bot.ResetBotPosition();
            bot.RemoveAllBrick();
        }
    }

}
