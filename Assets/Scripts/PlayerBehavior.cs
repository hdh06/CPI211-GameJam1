using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Below line is used to reference gameStarted variable in the cannon's script -- can be moved to a separate controller script
    private CannonBehavior cannonBehavior;

    [SerializeField] float ballMovementSpeed = 10f; // Speed at which ball moves when left/right key is pressed
    private Rigidbody rbBall;

    // Player control variables
    private bool movingLeft = false;
    private bool movingRight = false;

    void Start()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Control ball movement, updated in FixedUpdate
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            movingLeft = true;
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            movingRight = true;
        }
    }

    void FixedUpdate()
    {
        if (!cannonBehavior.gameStarted) return; // Ignore the rest of this if the ball is still in the cannon

        // CURRENTLY NOT WORKING PROPERLY!
        if (movingLeft)
        {
            Debug.Log("Player moving left");
            rbBall.AddForce(Vector3.left * ballMovementSpeed, ForceMode.Acceleration);
        }

        if (movingRight)
        {
            Debug.Log("Player moving right");
            rbBall.AddForce(Vector3.right * ballMovementSpeed, ForceMode.Acceleration);

        }
    }
}
