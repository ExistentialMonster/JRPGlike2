using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightInterface : MonoBehaviour
{
    [SerializeField] GameObject FightUI;
    bool playerTurn = false;
    int chosenElemIndex;

    enum UITabs{
        Attack,
        Spells,
        Items,
        RunAway,
        Surrend
    }

    int curTabId;

    [SerializeField] int[] spellsIds;

    UITabs curTab = UITabs.Attack;
    void Start()
    {
        //spellsIds = PlayerStats.spellsIds;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            curTabId = (curTabId + 1) % 2;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("hui");
            curTabId = (curTabId + 1) % 2;
        }
        switch (curTabId) {
            case 0:
                {
                    Debug.Log("Attack");
                    break;
                        }
            case 1:
                {
                    if (Input.GetKeyDown(KeyCode.D)) 
                    {
                        chosenElemIndex = (chosenElemIndex + 1) % spellsIds.Length;
                    }
                    
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        chosenElemIndex = (chosenElemIndex + spellsIds.Length - 1) % spellsIds.Length;
                    }

                    Debug.Log("Spell" + (chosenElemIndex).ToString());
                    break;
                }
        
        }    
    }


    public void PlayerTurn()
    {
        FightUI.gameObject.SetActive(true);
        curTab = UITabs.Attack;
        curTabId = 0;
        playerTurn = true;
    }
}
