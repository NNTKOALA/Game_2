using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static BrickController;

public class Player : MonoBehaviour
{
    public enum AnimationType
    {
        Idle, Run, Dance
    }

    public float speed = 5f;
    [SerializeField] Animator Anim;
    [SerializeField] FloatingJoystick variableJoystick;
    [SerializeField] GameObject brickPrefab;
    [SerializeField] Transform brickTransform;
    [SerializeField] SkinnedMeshRenderer skinMeshRenderer;

    private float yPos;

    public List<GameObject> listBrickHave = new List<GameObject>();
    public int BrickCount => listBrickHave.Count;
    private AnimationType currentAnimType = AnimationType.Idle;
    public ColorType colorType;
    public ColorType ColorType => colorType;
    public Rigidbody rb;
    public ColorData colorData;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        skinMeshRenderer.material = colorData.mats[(int)colorType];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Mathf.Abs(variableJoystick.Horizontal) > 0.1f && Mathf.Abs(variableJoystick.Vertical) > 0.1f)
            {
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(variableJoystick.Horizontal, 0f, variableJoystick.Vertical));
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 30f);
            }

            ChangeAnim(AnimationType.Run);
            this.transform.position = new Vector3(this.transform.position.x + variableJoystick.Horizontal * speed * Time.deltaTime,
                yPos, this.transform.position.z + variableJoystick.Vertical * speed * Time.deltaTime);

            //this.transform.LookAt(Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ChangeAnim(AnimationType.Idle);
        }
    }

    void ChangeAnim(AnimationType _type)
    {
        if (currentAnimType != _type)
        {
            currentAnimType = _type;
            switch (_type)
            {
                case AnimationType.Idle:
                    Anim.SetTrigger("Idlling");
                    break;
                case AnimationType.Run:
                    Anim.SetTrigger("Running");
                    break;
                case AnimationType.Dance:
                    Anim.SetTrigger("Dancing");
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BrickController brick = other.GetComponent<BrickController>();
        if (brick != null && brick.colorType == this.colorType)
        {
            brick.BrickEaten();
            GameObject obj = Instantiate(brickPrefab, brickTransform);
            obj.GetComponent<BrickController>().ChangeColor(colorType);
            obj.GetComponent<BrickController>().enabled = false;

            obj.transform.localPosition = new Vector3(0f, listBrickHave.Count * 0.3f, 0f);
            listBrickHave.Add(obj);
        }
    }

    public void SetYPosition(float yPosition)
    {
        yPos = yPosition;
    }

    public void RemoveBrick()
    {
        GameObject brick = listBrickHave[listBrickHave.Count - 1];
        Destroy(brick);

        listBrickHave.Remove(brick);
    }

    public void RemoveAllBrick()
    {
        foreach(var obj in listBrickHave)
        {
            Destroy(obj);
        }

        listBrickHave.Clear();
    }

    public void ResetPlayerPosition()
    {
        transform.position = startPos;
        yPos = 0f;
    }
}
