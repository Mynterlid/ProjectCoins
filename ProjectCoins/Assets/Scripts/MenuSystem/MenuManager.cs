using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _moveSettingsPopup;

    public void GameScene()
    {
        if (PlayerPrefs.GetString("MoveSettings") == "")
        {
            _moveSettingsPopup.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    
    public void SettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ActivateToGameButton()
    {
        GameObject.Find("ButtonToGame").GetComponent<Button>().interactable = true;
    }
}
