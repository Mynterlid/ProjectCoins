using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    private int _counterScore;
    
    private void Start()
    {
        Instance = this;
        _counterScore = 0;
    }

    public void AddScore(int countAdd)
    {
        this._counterScore += countAdd;
        _scoreText.text = this._counterScore.ToString();
        EnableScore();
        TimerScore();
    }

    private void ClearScore()
    {
        this._counterScore = 0;
        _scoreText.text = this._counterScore.ToString();
    }

    private void EnableScore()
    {
        _scoreText.gameObject.SetActive(true);
        _scoreText.gameObject.transform.parent.gameObject.SetActive(true);
    }
    
    private void DisableScore()
    {
        _scoreText.gameObject.SetActive(false);
        _scoreText.gameObject.transform.parent.gameObject.SetActive(false);
        ClearScore();
    }

    private void TimerScore()
    {
        CancelInvoke();
        Invoke("DisableScore", 3);
    }
}
