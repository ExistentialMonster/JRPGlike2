using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightControll : MonoBehaviour
{
    [SerializeField] GameObject Enemies;
    [SerializeField] GameObject Player;
    bool st = false;
    void Start()
    {
        gameObject.GetComponent<FightPlayer>().PlayerTurn();
    }

    

    // Update is called once per frame
    void Update()
    {
    }

    public void EndPlayerTurn()
    {
        GetComponent<FightEnemy>().EnemiesTurn();
        Debug.Log("PlayerTurnEnded");
    }

    public void EndEnemiesTurn()
    {
        Debug.Log("EnemyiesTurnEnded");
        GetComponent<FightPlayer>().PlayerTurn();
        
    }

    public void Defeat()
    {
        Debug.Log("So sad");
    }
}
