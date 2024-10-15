using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnemy : MonoBehaviour
{
    bool turn = false;
    [SerializeField] GameObject[] enemyies;
    TargetBoard board;
    int curEnemy = 0;
    void Start()
    {
    }

    // Update is called once per frame



    public void EnemiesTurn()
    {
        curEnemy = -1;
        NextEnemy();
    }

    public void NextEnemy()
    {
        Debug.Log(curEnemy);
        
        curEnemy++;
        if (curEnemy >= enemyies.Length)
        {
            gameObject.GetComponent<FightControll>().EndEnemiesTurn();
            return;
        }
        enemyies[curEnemy].GetComponent<EnemyToken>().EnemyGo(GetComponent<FightEnemy>());
    }


}
