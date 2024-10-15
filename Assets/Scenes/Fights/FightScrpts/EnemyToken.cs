using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyToken : MonoBehaviour
{
    bool stunned = false;
    int stunCount = 0;
    int stunTime = 1;
    public string Name = "h";

    int hp = 100;
    internal void SetName(string name)
    {
        Name = name;
    }
    
    public void GetStunned()
    {
        stunned = true;
        Debug.Log(Name + " stunned");
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        Debug.Log(hp);
    }

    public virtual void EnemyGo(FightEnemy fightEnenemySignal)
    {
        int attackNum;
        attackNum = Random.Range(0, 1);
        switch (attackNum)
        {
            case 0:
                {
                    HitPlayer();
                    break;
                }
            case 1:
                {
                    HitMyself();
                    break;
                }
        }
        fightEnenemySignal.NextEnemy();
    }

    void HitPlayer()
    {
        FindAnyObjectByType(typeof(FightInterface)).GetComponent<FightInterface>().GetDamage(10);
    }

    void HitMyself()
    {
        GetDamage(1);
    }
}
