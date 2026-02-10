using UnityEngine;

public class DangerCollide : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Danger"))
        {
            Destroy(gameObject);
        }
    }
}
