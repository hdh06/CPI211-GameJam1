using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject gameOverUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            Die();
        }
    }

    void Die()
    {
        gameOverUI.SetActive(true);
        Destroy(gameObject);
    }
}
