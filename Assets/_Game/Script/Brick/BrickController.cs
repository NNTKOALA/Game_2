using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum ColorType { None = 0, Yellow = 1, Red = 2, Green = 3, Purple = 4 }
public class BrickController : MonoBehaviour
{
    
    [SerializeField] Renderer meshRenderer;
    [SerializeField] ColorData colorData;
    public ColorType colorType = ColorType.Red;
    public ObjectPool Pool { get; set; }

    void Start()
    {
        StartCoroutine(ResetBrick(0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator ResetBrick(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        meshRenderer.gameObject.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = true;
        colorType = (ColorType)Random.Range(1, 5);
        meshRenderer.material = colorData.mats[(int)colorType];

    }

    public void BrickEaten()
    {
        meshRenderer.gameObject.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(ResetBrick(5f));
    }

    public void ChangeColor(ColorType colorType)
    {
        meshRenderer.material = colorData.mats[(int)colorType];
    }
}
