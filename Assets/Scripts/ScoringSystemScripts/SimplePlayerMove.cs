using UnityEngine;

public class SimplePlayerMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        gameObject.tag = "Player";
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        rb.AddForce(movement * speed);
    }
}