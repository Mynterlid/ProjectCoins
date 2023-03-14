using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _keyboardOn;
    [SerializeField] private GameObject _keyboardOff;
    [SerializeField] private GameObject _mouseAndKeyboardOn;
    [SerializeField] private GameObject _mouseAndKeyboardOff;
    [SerializeField] private GameObject _mouseOn;
    [SerializeField] private GameObject _mouseOff;
    
    private void Start()
    {
        switch (PlayerPrefs.GetString("MoveSettings"))
        {
            case "Keyboard": KeyboardButton();
                break;
                
            case "MouseAndKeyboard": MouseAndKeyboardButton();
                break;
            
            case "Mouse": MouseButton();
                break;
        }
    }

    public void ToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void KeyboardButton()
    {
        DoButtonsOff();
        PlayerPrefs.SetString("MoveSettings", "Keyboard");
        _keyboardOff.SetActive(false);
        _keyboardOn.SetActive(true);
    }

    public void MouseAndKeyboardButton()
    {
        DoButtonsOff();
        PlayerPrefs.SetString("MoveSettings", "MouseAndKeyboard");
        _mouseAndKeyboardOff.SetActive(false);
        _mouseAndKeyboardOn.SetActive(true);
        
    }
    
    public void MouseButton()
    {
        DoButtonsOff();
        PlayerPrefs.SetString("MoveSettings", "Mouse");
        _mouseOff.SetActive(false);
        _mouseOn.SetActive(true);
    }

    private void DoButtonsOff()
    {
        _keyboardOn.SetActive(false);
        _mouseAndKeyboardOn.SetActive(false);
        _mouseOn.SetActive(false);
        
        _keyboardOff.SetActive(true);
        _mouseAndKeyboardOff.SetActive(true);
        _mouseOff.SetActive(true);
    }
}
