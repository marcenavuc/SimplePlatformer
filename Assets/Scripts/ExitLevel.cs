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
        SceneManager.LoadScene("Level2");
    }
}
