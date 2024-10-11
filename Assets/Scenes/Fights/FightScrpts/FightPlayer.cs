using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FightPlayer : MonoBehaviour
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



    public void PlayerTurn()
    {
        turn = true;
        FindFirstObjectByType(typeof(FightInterface)).GameObject().GetComponent<FightInterface>().PlayerTurn();
    }

    void TurnMenu()
    {
        if (turn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FindObjectOfType<FightControll>().EndPlayerTurn();
            }
        }
    }

    
}
