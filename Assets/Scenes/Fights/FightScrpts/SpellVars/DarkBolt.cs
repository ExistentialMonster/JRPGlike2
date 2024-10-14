using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBolt : EnemyTargetSpell
{
    // Start is called before the first frame update
    public override void HitEnemy(EnemyToken enemy, FightInterface signalUI)
    {
        base.HitEnemy(enemy, signalUI);
        enemy.GetDamage(20);
        signalUI.turnVol -= 2;
    }
}
