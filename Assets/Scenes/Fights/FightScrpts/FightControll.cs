using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightControll : MonoBehaviour
{
    [SerializeField] GameObject Enemies;
    [SerializeField] GameObject Player;
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Player.GetComponent<FightPlayer>().PlayerTurn();
        }
    }

    public void EndPlayerTurn()
    {
        Enemies.GetComponent<FightEnemy>().EnemiesTurn();
    }

    public void EndEnemiesTurn()
    {
        Player.GetComponent<FightPlayer>().PlayerTurn();
    }
}
