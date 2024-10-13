using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetSpell : Spell
{
    // Start is called before the first frame update
    public override void UseSpell(FightInterface signalUI)
    {
        base.UseSpell(signalUI);
        signalUI.StartSpellTarget();
    }

    public virtual void HitEnemy(EnemyToken enemy)
    {
        
    }
}
