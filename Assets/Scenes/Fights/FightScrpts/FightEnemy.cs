using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnemy : MonoBehaviour
{
    bool turn = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TurnMenu();
    }



    public void EnemiesTurn()
    {
        turn = true;
    }

    void TurnMenu()
    {
        if (turn)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FindObjectOfType<FightControll>().EndEnemiesTurn();
            }
        }
    }


}
