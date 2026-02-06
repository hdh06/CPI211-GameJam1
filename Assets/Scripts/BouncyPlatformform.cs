using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody rigidPlayer;
    private Rigidbody rigid;

    void Start()
    {
        rigid = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collidedWithThis)
    {
        if (collidedWithThis.transform.name == "Player")
        {
            rigidPlayer.linearVelocity = transform.up * speed;
        }
    }
}
