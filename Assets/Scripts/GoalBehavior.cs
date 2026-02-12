using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    [SerializeField] private GameObject confetti; // Yay!!!!!
    private Rigidbody rb;

    void OnCollisionEnter(Collision ballCollision)
    {
        if (ballCollision.gameObject.tag == "Player")
        {
            rb = ballCollision.rigidbody; // Assigns ball's Rigidbody for collision

            // Freezes the ball
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;

            // Adds confetti! (Position adjusted to move the confetti into place)
            Instantiate(confetti, rb.transform.position + Vector3.down * 0.5f, Quaternion.identity);

            //  Woohoo!
            Debug.Log("You made it!!!");

        }

    }
}
