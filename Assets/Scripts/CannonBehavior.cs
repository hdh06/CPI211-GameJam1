using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab; // Player-controlled ball
    [SerializeField] private float shotMagnitude = 15f; // Intensity of shot from cannon
    GameObject ball;
    Rigidbody rbBall;
    bool ballShot = false;

    void Start()
    {
        // Places ball directly above placeholder cannon shape
        ball = Instantiate(ballPrefab, transform.position + new Vector3(0,1.5f,0), transform.rotation);
        rbBall = ball.GetComponent<Rigidbody>();

        // May not be needed after cannon model is added, as the ball will be able to fall inside the cannon before it's shot
        rbBall.useGravity = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !ballShot)
        {
            Debug.Log("Space pressed -- cannon triggered"); // Shows in Console view
            
            // Re-enables gravity -- delete when cannon model is added (explanation above)
            rbBall.useGravity = true;
            
            // Shoots from the up axis of the cannon
            rbBall.AddForce(transform.up * shotMagnitude, ForceMode.Impulse);
            
            // Disables ability for this script to add force to the ball after it's in the air
            ballShot = true;
            
        }
    }
}
