using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class MainMenu : MonoBehaviour
    {
        public void ExitGame()
        {
            Application.Quit();
        }

        public void OpenLevelSelector()
        {
            SceneManager.LoadScene("LevelSelector");
        }

        public void StartNewGame()
        {
            SceneManager.LoadScene("Level1");
        }
        
    }
}
