using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spell
{
    int turnCost;
    public virtual void UseSpell(FightInterface signalUI)
    {
        if (signalUI.turnVol < turnCost)
        {
            Debug.Log("cantUse");
            return;
        }
    }
}
