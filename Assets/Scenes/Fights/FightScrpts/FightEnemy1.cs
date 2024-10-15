using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.Experimental;

public class FightEnemy1 : EnemyToken
{
    private void Awake()
    {
        Name = "FightEnemy1";
    }


    public override void EnemyGo(FightEnemy signal)
    {
        base.EnemyGo(signal);


    }

    void HitPlayer()
    {
        FindAnyObjectByType(typeof(FightInterface));
    }
}
