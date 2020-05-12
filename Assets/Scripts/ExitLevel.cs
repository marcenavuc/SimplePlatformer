using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>())
            GoToNextLevel();
    }

    private void GoToNextLevel()
    {
        var currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level5")
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
}
