using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public enum AnimationType
    {
        Idle, Run, Dance
    }

    [SerializeField] Transform testNavMeshMoveFloor1;
    [SerializeField] Transform testNavMeshMoveFloor2;
    public Transform testNavMeshMove;
    [SerializeField] Animator Anim;
    [SerializeField] NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] GameObject brickPrefab;
    [SerializeField] Transform brickTransform;
    [SerializeField] SkinnedMeshRenderer skinMeshRenderer;
    [SerializeField] LayerMask brickLayer;

    public StateMachine stateMachine;

    private float yPos;
    public float speed = 5f;
    public List<GameObject> listBrickHave = new List<GameObject>();
    public int BrickCount => listBrickHave.Count;
    private AnimationType currentAnimType = AnimationType.Idle;
    public ColorType colorType;
    public ColorType ColorType => colorType;
    public ColorData colorData;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        skinMeshRenderer.material = colorData.mats[(int)colorType];
        agent = this.GetComponent<NavMeshAgent>();
        testNavMeshMove = testNavMeshMoveFloor1;
       // agent.SetDestination(testNavMeshMoveFloor1.position);
        ChangeAnim(AnimationType.Run);

        stateMachine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public GameObject GetClosestBrickOfType(ColorType type)
    {
        Collider[] bricks = Physics.OverlapSphere(transform.position, 20f, brickLayer);
        foreach (Collider col in bricks)
        {
            if(col.GetComponent<BrickController>().colorType == type)
            {
                return col.gameObject;
            }
        }

        return null;
    }

    public void RemoveBrick()
    {
        GameObject brick = listBrickHave[listBrickHave.Count - 1];
        Destroy(brick);

        listBrickHave.Remove(brick);
    }

    public void ChanggeDestination()
    {
        testNavMeshMove = testNavMeshMoveFloor2;
        stateMachine.ChangeState(stateMachine.states[0]);
    }

    public void RemoveAllBrick()
    {
        for (int i = 0; i < listBrickHave.Count; i++)
        {
            RemoveBrick();
        }
    }

    public void ResetBotPosition()
    {
        agent.ResetPath();
        agent.enabled = false;
        transform.position = startPos;
        agent.enabled = true;
    }
}
