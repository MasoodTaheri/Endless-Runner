using Player;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed;
    public bool switchLane;
    public Vector3 currentSpeed;
    public Vector3 targetpos;
    private bool isGameFinished = false;

    public Vector3[] Lane = new Vector3[3]
    {
        new Vector3(-3f, 0f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(3f, 0f, 0f)
    };

    public int currentLane;

    public float laneSwitchSpeed;
    public Vector3 jumpForce;
    [SerializeField] private SwipeDetection swipeDetection;
    private GameEventManager _gameEventManager;

    public void Start()
    {
        //Physics.gravity = new Vector3(0f, -9.81f, 0f);
        Physics.gravity = new Vector3(0f, -9.81f * 2, 0f);
        swipeDetection.OnLeft = SwipeLeft;
        swipeDetection.OnRight = SwipeRight;
        _gameEventManager.OnGameFinished.AddListener(() =>
        {
            Debug.Log("Game finished");
            isGameFinished = true;
            rb.velocity=Vector3.zero;
        });
    }

    private void SwipeRight()
    {
        if (currentLane + 1 <= 2)
        {
            currentLane += 1;
            switchLane = true;
        }
    }

    private void SwipeLeft()
    {
        if (currentLane - 1 >= 0)
        {
            currentLane -= 1;
            switchLane = true;
        }
    }

    public void Update()
    {
        if (isGameFinished)
            return;
        if (switchLane)
            return;
        /*  if (Input.GetKeyDown(KeyCode.LeftArrow))
          {
             SwipeLeft();
          }

          if (Input.GetKeyDown(KeyCode.RightArrow))
          {
            SwipeRight();
          }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    public void FixedUpdate()
    {  
        if (isGameFinished)
            return;
        //rb.MovePosition(rb.position + Vector3.up * Time.deltaTime);
        //rb.AddForce(transform.forward * Speed, ForceMode.VelocityChange);
        rb.velocity = transform.forward * Speed + new Vector3(0, rb.velocity.y, 0);
        currentSpeed = rb.velocity;
        if (switchLane)
        {
            rb.MovePosition(Vector3.Lerp(rb.position, new Vector3(Lane[currentLane].x, rb.position.y, rb.position.z),
                laneSwitchSpeed * Time.fixedDeltaTime));
            //Debug.Log(Mathf.Abs(rb.position.x - Lane[currentLane].x));
            if (Mathf.Abs(rb.position.x - Lane[currentLane].x) < 0.2f)
            {
                switchLane = false;
                rb.position = new Vector3(Lane[currentLane].x, rb.position.y, rb.position.z);
                //rb.MovePosition(rb.position + Lane[currentLane]);
            }
        }
    }

    public void Initialize(GameEventManager gameEventManager)
    {
        _gameEventManager = gameEventManager;
    }
}