using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LostGame : MonoBehaviour
{
    // Splash particle effect for snow
    [SerializeField] private GameObject splashPrefab;
    private GameObject ball;

    // To restart the game
    [HideInInspector] public bool gameLost = false;

    void OnCollisionEnter(Collision ballCollision)
    {
        ball = ballCollision.gameObject; // Assigns ball for collision

        if (ball.tag == "Player")
        {
            // Adds snow effect right below where the ball fell
            Instantiate(splashPrefab, ball.transform.position - Vector3.down, Quaternion.identity);

            // Shoots the ball out in a specific direction
            Destroy(ball);

            // Restarts game
            StartCoroutine(RestartGameIn(1f));
        }
    }

    IEnumerator RestartGameIn(float waitTime)
    {
        // Wait for a bit
        yield return new WaitForSeconds(waitTime);

        // Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
