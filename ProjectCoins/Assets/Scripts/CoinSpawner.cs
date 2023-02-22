using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    const int _minCountBigCoins = 40;
    const int _minCountSmallCoins = 40;
    
    [SerializeField] private GameObject _bigCoin;
    [SerializeField] private Transform _bigCoinTransform;
    [SerializeField] private GameObject _smallCoin;
    [SerializeField] private Transform _smallCoinTransform;
    
    [SerializeField][Range(80, 150)] private int _maxCountAllCoins;
    
    private int _maxCountBigCoins;
    private int _maxCountSmallCoins;
    
    void Start()
    {
        _maxCountBigCoins = _maxCountAllCoins - _minCountBigCoins;
        _maxCountSmallCoins = _maxCountAllCoins - _minCountSmallCoins ;
        
        for (int _countCoins = 1; _countCoins <= _maxCountAllCoins; _countCoins++)
        {
            SpawnCoins(_countCoins);
        }
    }

    void SpawnCoins(int _countCoins)
    {
        Debug.Log(_countCoins);
        if (_countCoins <= _maxCountBigCoins)
        {
            Instantiate(_bigCoin, _bigCoinTransform);
        }
        else
        {
            Instantiate(_smallCoin, _smallCoinTransform);
        }
    }
}
