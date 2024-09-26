using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IInteractableObject 
{
    [SerializeField] int EnemyId = 0;
    [SerializeField] public GameObject CurCell;
    void Start()
    {
        CurCell.GetComponent<Cell>().accupated = true;
        CurCell.GetComponent<Cell>().UsedBy = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseObject()
    {
        FindFirstObjectByType(typeof(FightManager)).GetComponent<FightManager>().StartFight(EnemyId);
    }
}
