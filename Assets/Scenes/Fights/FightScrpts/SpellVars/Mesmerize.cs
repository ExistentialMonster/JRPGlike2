using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesmerize : EnemyTargetSpell
{
    override public void UseSpell(FightInterface signalUI)
    {
        base.UseSpell(signalUI);
        
    }

    public override void HitEnemy(EnemyToken enemy, FightInterface signalUI)
    {
        base.HitEnemy(enemy, signalUI);

        enemy.GetStunned();
        signalUI.turnVol -= 1;
    }
}
