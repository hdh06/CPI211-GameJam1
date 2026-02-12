using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitOrRestartGame : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // Quit game
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(RestartGameIn(1f));
        }
    }

    // Restarts the game
    public IEnumerator RestartGameIn(float waitTime)
    {
        // Wait for a bit
        yield return new WaitForSeconds(waitTime);

        // Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
