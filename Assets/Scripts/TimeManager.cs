using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Image circleImage;
    
    [Header("Variables")]
    [SerializeField, MinValue(0f)] private float fullTimer = 10f;
    [SerializeField, MinValue(0)] private int nOfDivisions = 4;

    [Header("Debug")] 
    [SerializeField, ReadOnly] private int debugRound = 0;
    [SerializeField, ReadOnly] private float debugFill = 0;

    private float _t;
    private float _sectionTimer;
    private int _sectionCounter;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _sectionTimer = fullTimer / nOfDivisions;
    }

    // Update is called once per frame
    private void Update()
    {
        GeneralTimer();
    }

    private void GeneralTimer()
    {
        _t += Time.deltaTime;

        debugFill = (float)_sectionCounter / nOfDivisions + _t / _sectionTimer / nOfDivisions;
        circleImage.fillAmount = debugFill;

        if (_t >= _sectionTimer)
        {
            _t = 0;
            _sectionCounter++;
            SectionAction();

            if (_sectionCounter >= nOfDivisions)
            {
                _sectionCounter = 0;
                LoopStartAction();
            }
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
    }
}
