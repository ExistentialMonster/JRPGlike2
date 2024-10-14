using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FightInterface : MonoBehaviour
{
    bool playerTurn = false;
    public int turnVol = 0;

    int curTabId;

    int chosenElemIndex;

    [SerializeField] int[] spellsIds = { 0, 1 };

    int enemyTargetingSpellId = 0;
    bool isTargettingEnemy = false;

    GameObject[] curEnemyTokens;
    int enemyTargetId;


    enum UITabs{
        Attack,
        Spells,
        Items,
        RunAway,
        Surrend
    }


    void Start()
    {
        //spellsIds = PlayerStats.spellsIds;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn)
        {
            if (turnVol <= 0)
            {
                playerTurn = false;
            }
            if (playerTurn)
            {
                if (!isTargettingEnemy)
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
                    switch (curTabId)
                    {
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
                                    Debug.Log(chosenElemIndex);
                                }

                                if ((Input.GetKeyDown(KeyCode.Space)))
                                {
                                    Spells.SpellBag[spellsIds[chosenElemIndex]].UseSpell(gameObject.GetComponent<FightInterface>());
                                }

                                //Debug.Log("Spell" + (chosenElemIndex).ToString());
                                break;
                            }
                    }
                }
                else
                {
                    curEnemyTokens = FindAnyObjectByType(typeof(TargetBoard)).GameObject().GetComponent<TargetBoard>().EnemyTokens;
                    if (Input.GetKey(KeyCode.A))
                    {
                        enemyTargetId = (enemyTargetId + curEnemyTokens.Length - 1) % curEnemyTokens.Length;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        enemyTargetId = (enemyTargetId + 1) % curEnemyTokens.Length;
                    }
                    if (Input.GetKey(KeyCode.Backspace))
                    {
                        EnemyTargetSpell hitTargetSpell = (EnemyTargetSpell)Spells.SpellBag[enemyTargetingSpellId];
                        hitTargetSpell.HitEnemy(curEnemyTokens[enemyTargetId].GetComponent<EnemyToken>(), gameObject.GetComponent<FightInterface>());
                        isTargettingEnemy = false;
                    }
                    if (Input.GetKey(KeyCode.Escape))
                    {
                        isTargettingEnemy = false;
                    }
                }

            }
            else
            {
                FindFirstObjectByType<FightControll>().gameObject.GetComponent<FightControll>().EndPlayerTurn();
            }
        }
        }


    public void StartSpellTarget()
    {
        isTargettingEnemy = true;
        enemyTargetingSpellId = spellsIds[chosenElemIndex];
        enemyTargetId = 0;
    }

    public void PlayerTurn()
    {
        curTabId = 0;
        playerTurn = true;
        turnVol = 3;
    }
}
