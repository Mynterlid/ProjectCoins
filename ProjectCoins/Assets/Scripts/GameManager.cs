using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _ButtonE; 
    private void Start()
    {
        Instance = this;
    }

    public void ActivateEButton()
    {
        _ButtonE.SetActive(true);
    }

    public void DeactivateEButton()
    {
        _ButtonE.SetActive(false);
    }

}
