using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Below lines are used to reference gameStarted variable in the cannon's script
    [HideInInspector] public CannonBehavior cannonBehavior;
    [SerializeField] private GameObject cannon;

    // Player movement variables
    [SerializeField] private float movementSpeed = 5f;
    private Rigidbody rb;
    private float moveInputX;

    void Start()
    {
        cannonBehavior = cannon.GetComponent<CannonBehavior>();
        rb = GetComponent<Rigidbody>();
        gameObject.tag = "Player";
    }

    void Update()
    {
        // Doesn't let you move until ball is shot from the cannon
        if (cannonBehavior.gameStarted)
        { 
            // Player movement control (A / LeftArrow, D / RightArrow keys)
            moveInputX = Input.GetAxis("Horizontal") * -1;
        }
    }
    void FixedUpdate()
    {
        if (cannonBehavior.gameStarted)
        {
            // Changes velocity based on input
            rb.linearVelocity = new Vector3(rb.linearVelocity.x + moveInputX * movementSpeed * 0.1f, rb.linearVelocity.y, rb.linearVelocity.z);
        }
    }
}
