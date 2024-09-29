using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyTurn()
    {
        while (Input.GetKeyDown(KeyCode.Space) != true) { 
        }
        Debug.Log("ahhahant");

        FindObjectOfType<FightControll>().EndEnemiesTurn();
    }
}
