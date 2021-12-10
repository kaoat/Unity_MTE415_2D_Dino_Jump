using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllingScript : MonoBehaviour
{
    [SerializeField] private float JUMP_POWER;
    [SerializeField] private float RUN_SPEED;
    [SerializeField] private float RAYCAST_DISTANCE;
    [SerializeField] private string IS_DIED_PARAM_ANIMATOR;
    [SerializeField] private string IS_GROUND_PARAM_ANIMATOR;
    [SerializeField] private string IS_RUN_PARAM_ANIMATOR;

    [SerializeField] private GameObject groundDetector;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private string enemyTagName;

    private const int ROTATION_NEGATIVE_180=-180;
    private const int ROTATION_0 = 0;

    private Rigidbody2D playerRig;
    private Quaternion newRotation;
    private Vector2 force;
    private bool isGround;
    private bool isLeftDirection;
    private bool isRun;
    private bool isDied;
    private Animator animator;

    private void Awake()
    {
        newRotation = this.transform.rotation;
        playerRig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        force = new Vector2(RUN_SPEED, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        isDied = false;
        isRun = false;
        isLeftDirection = false;
        isGround = true;

        animator.SetBool(IS_RUN_PARAM_ANIMATOR, isRun);
        animator.SetBool(IS_GROUND_PARAM_ANIMATOR, isGround);
        animator.SetBool(IS_DIED_PARAM_ANIMATOR, isDied);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Environment.instance.isGameOver)
        {
            Environment.instance.playTime += Time.deltaTime;
            isRun = Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow);
            isLeftDirection = this.transform.rotation.y < ROTATION_0;
            isGround = CheckIsGround();

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGround && isRun)
            {
                Jump();
                Run();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow)&&isGround)
            {
                Jump();
            }
            else if (isRun&&isGround)
            {
                Run();
            }

            animator.SetBool(IS_GROUND_PARAM_ANIMATOR, isGround);
            animator.SetBool(IS_RUN_PARAM_ANIMATOR, isRun);
        }
    }

    bool CheckIsGround()
    {
        return Physics2D.Raycast(groundDetector.transform.position,Vector2.down,RAYCAST_DISTANCE,groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(enemyTagName))
        {
            isDied = true;
            animator.SetBool(IS_DIED_PARAM_ANIMATOR, isDied);
            Environment.instance.StopWorld();
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GoRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft();
        }
    }

    void Jump()
    {
        playerRig.AddForce(new Vector2(0, JUMP_POWER));
    }

    void GoLeft()
    {
        if (!isLeftDirection)
        {
            newRotation.y = ROTATION_NEGATIVE_180;
            this.transform.rotation = newRotation;
        }
        force.x = RUN_SPEED.ReflectValue();
        playerRig.AddForce(force);
    }
    
    void GoRight()
    {
        if (isLeftDirection)
        {
            newRotation.y = ROTATION_0;
            this.transform.rotation = newRotation;
        }

        force.x = RUN_SPEED;
        playerRig.AddForce(force);
    }
}
