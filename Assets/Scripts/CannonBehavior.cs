using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject ball; // Player-controlled ball
    [SerializeField] private float shotMagnitude = 15f; // Intensity of shot from cannon
    [SerializeField] private float cannonRotationSpeed = 14f;
    
    private Rigidbody rbBall; // Physics object for ball
    private bool spacePressed = false; // Key to trigger cannon
    bool gameStarted = false; // True after cannon shoots the ball
    
    void Start()
    {
        // Places ball directly above placeholder cannon shape
        rbBall = ball.GetComponent<Rigidbody>();

        // May not be needed after cannon model is added, as the ball will be able to fall inside the cannon before it's shot
        rbBall.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Debug.Log("Aiming left"); // Shows in Console view
            gameObject.transform.Rotate(Vector3.back * cannonRotationSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("Aiming right");
            gameObject.transform.Rotate(Vector3.forward * cannonRotationSpeed * Time.deltaTime, Space.Self);
        }

        // Key press to shoot cannon within FixedUpdate
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }

    }

    void FixedUpdate()
    {

        if (spacePressed && !gameStarted)
        {
            Debug.Log("Space pressed -- cannon triggered");
            
            // Re-enables gravity -- delete when cannon model is added (explanation above)
            rbBall.useGravity = true;
            
            // Shoots from the up axis of the cannon
            rbBall.AddForce(transform.up * shotMagnitude, ForceMode.Impulse);
            
            // Disables ability for this script to add force to the ball after it's in the air
            gameStarted = true;
            
        }
    }
}
