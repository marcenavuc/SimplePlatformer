using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    private GameObject buttons;
    private void Awake()
    {
        buttons = transform.GetChild(0).gameObject;
        buttons.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetPause();
    }

    public void SetPause()
    {
        Time.timeScale = 0;
        buttons.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        buttons.SetActive(false);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
}
