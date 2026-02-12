using UnityEngine;

public class MovementTest : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    private Rigidbody rb;
    private float moveInputX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.tag = "Player";
    }

    void Update()
    {
        // Player movement control
        moveInputX = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveInputX * movementSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
    }
}
