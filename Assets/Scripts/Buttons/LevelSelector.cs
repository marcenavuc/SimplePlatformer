using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class LevelSelector : MonoBehaviour
    {
        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void LoadLevel(int number)
        {
            SceneManager.LoadScene(number);
        }
    }
}
