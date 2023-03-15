using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _speed;
    
    private SpriteRenderer _playerRenderer;
    private int _widthScreen;
    private int _heightScreen;

    private void Start()
    {
        _playerRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        switch (PlayerPrefs.GetString("MoveSettings"))
        {
            case "Keyboard": KeyboardMove();
                break;
                
            case "MouseAndKeyboard": 
                if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
                {
                    MouseMove();
                }

                KeyboardMove();
                break;
            
            case "Mouse": 
                if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
                {
                    MouseMove();
                };
                break;
        }
    }

    private void MouseMove()
    {
        int middleWidthScreen = Screen.width / 2;

        if (Input.mousePosition.x <= middleWidthScreen)
        {
            transform.position = Vector2.Lerp(transform.position, 
                                            Camera.main.ScreenToWorldPoint(Input.mousePosition),  
                                            _speed / 100);
            _playerRenderer.flipX = true;
        }
        else if (Input.mousePosition.x > middleWidthScreen)
        {
            transform.position = Vector2.Lerp(transform.position, 
                                            Camera.main.ScreenToWorldPoint(Input.mousePosition),  
                                            _speed / 100);
            _playerRenderer.flipX = false;
        }
    }

    private void KeyboardMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * (_speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * (_speed * Time.deltaTime));
            _playerRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * (_speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * (_speed * Time.deltaTime));
            _playerRenderer.flipX = false;
        }
    }
}
