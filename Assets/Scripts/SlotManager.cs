using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

public class SlotManager : MonoBehaviour
{
    public static SlotManager Instance;
    
    [SerializeField, ReadOnly] private SlotTemp[] slots;

    public SlotTemp[] Slots { get; set; }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        slots = new SlotTemp[TimeManager.Instance.NOfDivisions];
    }
}

[Serializable]
public class SlotTemp
{
    public Card activeCard = null;
    public bool filled = false;

    public void Empty()
    {
        filled = false;
        activeCard = null;
    }
}


