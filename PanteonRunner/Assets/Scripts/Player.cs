using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    //Player
    public float moveSpeed;
    Rigidbody playerRB;
    Animator playerAnimator;

    //Drawing Object
    public Camera endCam;
    public GameObject endPlaneWall;


    //Touch Ýnput
    private Vector3 newPos = Vector3.zero;
    private bool localMovement;
    public Transform transMove;
    private float touchMoveSpeed = 0.1f;

    //Restart position
    Vector3 CurrentPosition;

    bool isMove = true;
    bool isStart = false;


    //Bounds
    [SerializeField] Transform rightBound;
    [SerializeField] Transform leftBound;

    //UI
    [SerializeField] GameObject tapToMove;



    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        CurrentPosition = transform.position;
    }


    private void FixedUpdate()
    {
        if (isStart)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {

        if (isMove)
        {
            //Touch_Input();
            Mouse_Input();
        }  
    }

    private void Mouse_Input()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            isStart = true;
            playerAnimator.SetBool("isMove", true);
            tapToMove.SetActive(false);

            Vector3 newPos = Vector3.zero;

            if (Input.GetAxis("Mouse X") < 0)
            {
                
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z), 0.3f);

            }

            if (Input.GetAxis("Mouse X") > 0)
            {
                
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), 0.3f);
            }
        }
    }

    private void Touch_Input()
    {
        Touch touch;

        if (Input.touchCount > 0)
        {

            isStart = true;
            playerAnimator.SetBool("isMove", true);
            tapToMove.SetActive(false);


            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {

                float newX = touch.deltaPosition.x * touchMoveSpeed * Time.deltaTime;
                newPos = localMovement ? transMove.localPosition : transMove.position;
                newPos.x += newX;
                newPos.x = Mathf.Clamp(newPos.x, leftBound.position.x, rightBound.position.x);

                if (localMovement)
                {
                    transMove.localPosition = newPos;
                }
                else
                {
                    transMove.position = newPos;
                }
            }

            
        }
    }


    private void OnTriggerStay(Collider other)
    {
        

        if (other.gameObject.CompareTag("BluePlatform"))
        {
            playerRB.AddForce(new Vector3(.2f, 0, 0) * 2f, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("YellowPlatform"))
        {
            playerRB.AddForce(new Vector3(-.2f, 0, 0) * 3f, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("PurplePlatform"))
        {
            playerRB.AddForce(new Vector3(.2f, 0, 0) * 4f, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StaticObstacle"))
        {
            transform.position = CurrentPosition;
        }

        if (other.gameObject.CompareTag("EndLine"))
        {
            isMove = false;
            moveSpeed = 0f;
            playerAnimator.SetBool("isMove", false);
            endCam.gameObject.SetActive(true);
            endPlaneWall.SetActive(true);
            
        }
    }
}
