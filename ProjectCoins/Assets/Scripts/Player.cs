using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _speed;
    
    private Rigidbody2D _playerRigidbody2D;
    private SpriteRenderer _playerRenderer;
    
    
    private void Start()
    {
        _playerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _playerRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
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
