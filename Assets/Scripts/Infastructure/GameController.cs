using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Services;
using Services.Data;
using Services.Services;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance => _instance;
    
    [SerializeField] public WindowService WindowService;
    [NonSerialized] public DataService DataService;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Bootstrap();
    }

    private void Bootstrap()
    {
        // Зависимости
        DataService = new DataService();
        WindowService.Initialize(DataService);
        
        WindowService.OpenWindow(WindowType.Main);
    }
}
