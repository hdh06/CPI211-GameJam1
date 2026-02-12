using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 100; // Value of the coin to be added to the player's score
    //public ParticleSystem collectEffect; // Optional: Particle effect to play when the coin is collected
    void Start()
        {
            SphereCollider collider = GetComponent<SphereCollider>();
            if (collider == null)
            {                
                collider = gameObject.AddComponent<SphereCollider>();
            }
            collider.isTrigger = true; // Set the collider to be a trigger
        }

        void Update()
        {
            transform.Rotate(0, 90 * Time.deltaTime, 0); // Rotate the coin around the Y-axis
        }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(coinValue); // Add the coin value to the player's score
            }
            
            Destroy(gameObject); // Destroy the coin after collection
        }
    }
}

   