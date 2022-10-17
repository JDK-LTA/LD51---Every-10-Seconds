using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public bool armor = false;
    [SerializeField, ReadOnly] private int lives = 3;
    
    private void Awake()
    {
        Instance = this;
    }

    public void GetAttacked()
    {
        if (!armor)
        {
            lives--;
        }
        else
        {
            armor = false;
        }
    }
}
