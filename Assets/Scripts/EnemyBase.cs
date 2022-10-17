using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, ReadOnly] protected int lives = 3;
    [SerializeField, ReadOnly] private int actionNumber = 0;
    [SerializeField, ReadOnly] protected int nOfSharpens = 0;
    [SerializeField, ReadOnly] protected EnemyActionBase[] actionList;

    private void Start()
    {
        actionList = new EnemyActionBase[TimeManager.Instance.NOfDivisions];
    }

    private void Action()
    {
        var enemyActionBase = actionList[TimeManager.Instance.SectionCounter];

        if (enemyActionBase is EnemyAttack && nOfSharpens > 0)
        {
            for (int i = nOfSharpens - 1; i >= 0; i--)
            {
                enemyActionBase.Action();
                nOfSharpens--;
            }
        }
        enemyActionBase.Action();
    }
}

[Serializable]
public abstract class EnemyActionBase
{
    public virtual void Action()
    {
        
    }
}

public class EnemyAttack : EnemyActionBase
{
    public override void Action()
    {
        PlayerManager.Instance.GetAttacked();       
    }
}
