using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

public class SlotManager : MonoBehaviour
{
    public static SlotManager Instance;

    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform clockImageTransform;
    [SerializeField] private float radiusOffsetForSlots = 5;
    [SerializeField, ReadOnly] private Slot[] slots;

    public Slot[] Slots { get => slots; set => slots = value; }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        slots = new Slot[TimeManager.Instance.NOfDivisions];

        Vector2[] coords = FindCoordinates();
        
        for (int i = 0; i < TimeManager.Instance.NOfDivisions; i++)
        {
            slots[i] = Instantiate(slotPrefab,  clockImageTransform.position + new Vector3(coords[i].x, coords[i].y), Quaternion.identity, clockImageTransform).GetComponent<Slot>();
        }
    }

    private Vector2[] FindCoordinates()
    {
        int nOfDivs = TimeManager.Instance.NOfDivisions;
        
        Vector2[] coords = new Vector2[nOfDivs];
        float rad = radiusOffsetForSlots;

        for (int i = 0; i < nOfDivs; i++)
        {
            float angle = i * (360 / nOfDivs);
            float radian = (angle * Mathf.PI / 180);
            coords[i] = new Vector2(0 + rad * Mathf.Sin(radian), 0 + rad * Mathf.Cos(radian));
        }

        return coords;
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