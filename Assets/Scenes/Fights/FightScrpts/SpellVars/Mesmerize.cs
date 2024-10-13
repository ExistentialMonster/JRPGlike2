using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesmerize : EnemyTargetSpell
{
    override public void UseSpell(FightInterface signalUI)
    {
        base.UseSpell(signalUI);
        
    }

    public override void HitEnemy(EnemyToken enemy)
    {
        base.HitEnemy(enemy);

        enemy.GetStunned();
    }
}
