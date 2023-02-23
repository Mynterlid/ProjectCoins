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
    [SerializeField][Range(65, 250)] private int distance;

    private List<GameObject> _bigCoinList = new List<GameObject>();
    private List<GameObject> _smallCoinList = new List<GameObject>();
    private int _maxCountBigCoins;
    private int _maxCountSmallCoins;
    private Vector3 _spawnPoint;
    
    void Start()
    {
        //Стоит создать отдельный метод для более четкой рандомизации
        _maxCountBigCoins = _maxCountAllCoins - _minCountBigCoins;
        _maxCountSmallCoins = _maxCountAllCoins - _minCountSmallCoins;
        
        for (int _countCoins = 1; _countCoins <= _maxCountAllCoins; _countCoins++)
        {
            SpawnCoins(_countCoins);
        }
    }

    private void SpawnCoins(int _countCoins)
    {
        if (_countCoins <= _maxCountBigCoins)
        {
            _bigCoinList.Add(Instantiate(
                _bigCoin, 
                ApproveDistanceBigCoin(_bigCoinList), 
                Quaternion.identity, 
                _bigCoinTransform)
            );
        }
        else
        {
            _smallCoinList.Add(Instantiate(
                _smallCoin, 
                ApproveDistanceSmallCoin(_bigCoinList, _smallCoinList), 
                Quaternion.identity, 
                _smallCoinTransform)
            );
        }
    }

    private Vector3 ApproveDistanceBigCoin(List<GameObject> coinList)
    {
        const int distanceBetweenCoins = 7; //Увеличение дистанции без увеличения радиуса спавна ломает Unity
        
        _spawnPoint = Random.insideUnitCircle * distance;
        
        for (int i = 0; i < coinList.Count; i++)
        {
            if (Vector3.Distance(_spawnPoint, coinList[i].transform.position) <= distanceBetweenCoins)
            {
                _spawnPoint = Random.insideUnitCircle * distance;
                i = 0;
            }
        }
        
        return _spawnPoint;
    }

    private Vector3 ApproveDistanceSmallCoin(List<GameObject> bigCoinList, List<GameObject> smallCoinList)
    {
        const int distanceBetweenCoins = 7; //Увеличение дистанции без увеличения радиуса спавна ломает Unity
        
        _spawnPoint = ApproveDistanceBigCoin(bigCoinList);
        
        for (int counterSmallCoin = 0; counterSmallCoin < smallCoinList.Count; counterSmallCoin++)
        {
            if (Vector3.Distance(_spawnPoint, smallCoinList[counterSmallCoin].transform.position) <= distanceBetweenCoins)
            {
                _spawnPoint = ApproveDistanceBigCoin(bigCoinList);

                counterSmallCoin = 0;
            }
        }
        
        return _spawnPoint;
    }
    
    //Реализация проверки расстояния до центра
    /*private Vector3 ApproveDistanceCenter()
    {
        
    }*/
}
