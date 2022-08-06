using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveModule : MonoBehaviour
{

    public Vector2 moveDir;

    public Vector2 savedDir;

    public float moveSpeed;
    private float temp;
    private float savedMoveSpeed;

    Vector3 startPos;
    public UnityEvent OnEscapeStage;

    public bool isCharted;


    public enum MoveType
    {
        Forward,
        Sin,
        HitAvoid,
    }

    public MoveType moveType;

    float sinTImer = 0;

    public void FixedUpdate()
    {
        transform.Translate(moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    bool reseted = false;

    float sinSign;

    public float sinSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        sinSign = Mathf.Sign(Random.Range(-5,5));
    }


    private void OnEnable()
    {
        if(startPos == Vector3.zero)
            startPos = transform.position;


        if (isCharted)
        {
            assigned = false;
            transform.position = startPos;
            if (!reseted)
            {
                savedDir = moveDir;
                reseted = true;
                savedMoveSpeed = moveSpeed;
            }

            moveDir = savedDir;

            moveSpeed = 1;
           
        }
    }

    
    public void SetSpeed()
    {
        moveSpeed = savedMoveSpeed;
    }

    bool assigned = false;

    public UnityEvent OnOutScreen;

    void Update()
    {
        Vector3 viewpos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewpos.y < 1.1f && isCharted)
        {
            OnEnterScreen?.Invoke();
            if (!assigned)
            {
                assigned = true;
                Debug.Log("화면 안으로 들어왔습니다. 저장한 속도를 할당합니다.");
                moveSpeed = savedMoveSpeed;

            }

            switch (moveType)
            {
                case MoveType.Forward:
                    break;
                case MoveType.Sin:
                    sinTImer += Time.deltaTime;
                    moveDir.x = Mathf.Sin(sinTImer) * sinSign * sinSpeed;
                    break;
            }

        }

        if(viewpos.y > 1.1f)
        {
            OnOutScreen?.Invoke();
        }

        if (viewpos.y < -0.1f)
        {
            OnEscapeStage?.Invoke();
            this.enabled = false;
        }

        else if(viewpos.x > 1 || viewpos.x < 0)
        {
            if (isRedCell) return;
            OnEscapeStage?.Invoke();
            this.enabled = false;
        }
        
    }
    public bool isRedCell;

    public UnityEvent OnEnterScreen;



    public void OnHIt()
    {
        if(moveDir.x == 0 )
            moveDir.x += Random.Range(-0.5f, .5f);
        else if (Mathf.Sign(moveDir.x) > 0)
            moveDir.x += Random.Range(0.2f, .5f);
        else if(Mathf.Sign(moveDir.x) < 0)
            moveDir.x -= Random.Range(0.2f, .5f);
 


    }


    public void AddSpeed(float amount)
    {
        moveSpeed += amount;
    }
}
