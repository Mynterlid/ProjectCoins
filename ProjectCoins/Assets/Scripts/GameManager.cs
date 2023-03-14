using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _buttonE;
    [SerializeField] private GameObject _pauseMenu;
    private void Start()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        CheckInput();
    }

    public void ActivateEButton()
    {
        _buttonE.SetActive(true);
    }

    public void DeactivateEButton()
    {
        _buttonE.SetActive(false);
    }

    public void SettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    
    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            OpenPauseMenu();
        }
    }

    private void OpenPauseMenu()
    {
        if (_pauseMenu.activeSelf)
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
