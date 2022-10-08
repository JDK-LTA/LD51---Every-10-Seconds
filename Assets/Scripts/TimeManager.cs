using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [Header("References")] [SerializeField, Required]
    private Image circleImage;

    [Header("Variables")] [SerializeField, MinValue(0f)]
    private float fullTimer = 10f;

    [SerializeField, MinValue(0)] private int nOfDivisions = 4;

    [Header("Debug")] [SerializeField, ReadOnly]
    private int debugRound = 0;

    [SerializeField, ReadOnly] private float debugFill = 0;

    private float _t;
    private float _sectionTimer;
    [SerializeField, ReadOnly] private int _sectionCounter;

    public int NOfDivisions => nOfDivisions;


    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        _sectionTimer = fullTimer / NOfDivisions;
    }

    // Update is called once per frame
    private void Update()
    {
        GeneralTimer();
    }

    private void GeneralTimer()
    {
        _t += Time.deltaTime;

        debugFill = (float)_sectionCounter / NOfDivisions + _t / _sectionTimer / NOfDivisions;
        circleImage.fillAmount = debugFill;

        if (_t >= _sectionTimer)
        {
            _t = 0;
            _sectionCounter++;
            
            if (_sectionCounter >= NOfDivisions)
            {
                _sectionCounter = 0;
                LoopStartAction();
            }

            SectionAction();
        }
    }

    private void LoopStartAction()
    {
        //print("Looping");
        debugRound++;
    }

    private void SectionAction()
    {
        //print("Section: " + _sectionCounter);

        Slot slotTemp = SlotManager.Instance.Slots[_sectionCounter];
        if (slotTemp.filled)
        {
            Card card = slotTemp.activeCard;
            if (card) card.CardAction();
            slotTemp.Empty();
        }
    }
}