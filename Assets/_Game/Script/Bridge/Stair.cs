using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stair : MonoBehaviour
{
    public ColorData colorData;
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
        if (other.GetComponent<Player>() != null)
        {
            Player player = other.GetComponent<Player>();
            if (player.BrickCount > 0)
            {
                player.RemoveBrick();
                player.SetYPosition(transform.position.y + 0.5f);
                MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                meshRenderer.enabled = true;
                meshRenderer.material = colorData.mats[(int)player.ColorType];
            }
        }

        if (other.GetComponent<Bot>() != null)
        {
            Bot bot = other.GetComponent<Bot>();
            if (bot.BrickCount > 0)
            {
                bot.RemoveBrick();
                bot.SetYPosition(transform.position.y + 0.5f);
                MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                meshRenderer.enabled = true;
                meshRenderer.material = colorData.mats[(int)bot.ColorType];
            }
        }
    }

}
