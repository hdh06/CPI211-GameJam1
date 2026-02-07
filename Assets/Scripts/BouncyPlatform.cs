using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private float bounceStrength = 5f;
    private float rotateStrength = 5f;

    void Start()
    {

    }

    void OnCollisionEnter(Collision collidedWithThis)
    {
        if (collidedWithThis.transform.name == "Player")
        {
            Rigidbody collideObject = collidedWithThis.rigidbody;
           // collideObject.linearVelocity = transform.up * bounceStrength;

            Vector3 incomingVelocity = collideObject.linearVelocity; 
            Vector3 normal = collidedWithThis.contacts[0].normal;
            Vector3 reflectedDirection = Vector3.Reflect(incomingVelocity.normalized, normal);
            collideObject.AddForce(reflectedDirection * bounceStrength, ForceMode.Impulse);
        }
    }

    void RotatePlayer(Rigidbody collideObject, Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.001f)
            return;

        Quaternion rotatePlayer = Quaternion.LookRotation(direction, Vector3.up);

        collideObject.MoveRotation(Quaternion.Slerp
            (collideObject.rotation, rotatePlayer, rotateStrength));
    }
}