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

        public void LoadFirstLevel()
        {
            SceneManager.LoadScene("Level1");
        }
        
        public void LoadSecondLevel()
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
