using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private float bounceStrength = 5f; 

    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collidedWithThis)
    {
        if (collidedWithThis.transform.name == "Player")
        {
            Rigidbody collideObject = collidedWithThis.rigidbody;
            collideObject.linearVelocity = transform.up * bounceStrength;
        }
    }
}
