using System;
using Unity.Mathematics;
using Unity.VisualScripting;
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
        /*Debug.Log($"{Camera.main.ScreenToWorldPoint(Input.mousePosition)} - camera position");
        Debug.Log(Vector2.Lerp(transform.position, 
            Camera.main.ScreenToWorldPoint(Input.mousePosition),  
            0));*/
       
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
        
        Vector2 LerpPostion = Vector2.Lerp(transform.position,
            MousePointPosition(),
            Time.deltaTime);

        if (Input.mousePosition.x <= middleWidthScreen)
        {
            transform.position = LerpPostion;
            _playerRenderer.flipX = true;
        }
        else if (Input.mousePosition.x > middleWidthScreen)
        {
            transform.position = LerpPostion;
            _playerRenderer.flipX = false;
        }
    }

    private Vector2 MousePointPosition()
    {
        Vector2 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (math.abs(MousePoint.x - transform.position.x) * Time.deltaTime > _speed * Time.deltaTime)
        {
            MousePoint.x = MousePoint.x - transform.position.x < 0 
                ? transform.position.x - 10
                : transform.position.x + 10;
        }
        
        if (math.abs(MousePoint.y - transform.position.y) * Time.deltaTime 
            > _speed * Time.deltaTime)
        {
            MousePoint.y = MousePoint.y - transform.position.y < 0 
                ? transform.position.y - 10
                : transform.position.y + 10;
        }

        float test = math.sqrt(math.pow(MousePoint.x - transform.position.x, 2) + math.pow(MousePoint.y - transform.position.y, 2));

        /*if (math.abs(MousePoint.x - transform.position.x) * Time.deltaTime 
            + math.abs(MousePoint.y - transform.position.y) * Time.deltaTime > _speed * Time.deltaTime)
        {
                        
        }*/

        MousePoint = new Vector2(transform.position.x + (MousePoint.x - transform.position.x) * _speed / test, transform.position.y + (MousePoint.y - transform.position.y) * );
        
        
        //Debug.Log(math.sqrt(math.pow(MousePoint.x - transform.position.x, 2) + math.pow(MousePoint.y - transform.position.y, 2)));
        
        Debug.Log(_speed / test);
        return MousePoint;
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
