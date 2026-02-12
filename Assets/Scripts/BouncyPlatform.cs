using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    [SerializeField] private float bounceStrength = 10f; // Adjustable in Inspector
    [SerializeField] private float bounceDistance = 10f; // Adjustable in Inspector

    void OnCollisionEnter(Collision ballCollision)
    {
        if (ballCollision.gameObject.tag == "Player")
        {
            // Shoots the ball out in a specific direction
            ballCollision.rigidbody.linearVelocity = (transform.up * bounceStrength + Vector3.back * bounceDistance);
        }

    }
}