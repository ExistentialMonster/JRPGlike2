using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ManagerPlayer : MonoBehaviour
{
    public GameObject DestCell;
    [SerializeField] public GameObject CurCell;

    public bool isMoving = false;

    [SerializeField] public float speed;
    public int dir;

    [SerializeField] Vector2 playerGlobalScale;

    Vision Controller;


    void Start()
    {
        Controller = GameObject.FindObjectOfType<Vision>();
    }

    public void SetCurCell()
    {
        transform.position = CurCell.transform.position;
        transform.localScale = playerGlobalScale * CurCell.GetComponent<Cell>().scaleCoef;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputMovement();
        GetInputInteraction();
        CheckAndMovePlayer();
        
    }

    void GetInputMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            dir = 0;
            CheckAndStartMovingToCell();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir = 1;
            CheckAndStartMovingToCell();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir = 2;
            CheckAndStartMovingToCell();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dir = 3;
            CheckAndStartMovingToCell();
        }
    }

    void GetInputInteraction()
    {
        if (!CurCell.GetComponent<Cell>().NearCells[dir].IsUnityNull())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IInteractableObject g;
                if (CurCell.GetComponent<Cell>().NearCells[dir].GetComponent<Cell>().UsedBy.TryGetComponent<IInteractableObject>(out g))
                {
                    g.UseObject();
                }
            }
        }
    }

    void CheckAndStartMovingToCell()
    {
        if (CurCell.GetComponent<Cell>().NearCells[dir] != null)
        {
            if (!CurCell.GetComponent<Cell>().NearCells[dir].GetComponent<Cell>().accupated & isMoving == false)
            {
                isMoving = true;
                DestCell = CurCell.GetComponent<Cell>().NearCells[dir];
            }
        }
    }

    void CheckAndMovePlayer()
    {
        if (isMoving) 
        {
            if (Vector2.Distance(DestCell.transform.position, transform.position) < speed * Time.deltaTime / 100)
            {
                isMoving = false;
                CurCell = DestCell;
                transform.position = CurCell.transform.position;
            }
            else
            {
                float curSpeed = speed / 15 * Vector2.Distance(CurCell.transform.position, DestCell.transform.position);
                Controller.MovePlayerToCell(DestCell.transform.position, 

                    DestCell.GetComponent<Cell>().scaleCoef, playerGlobalScale,

                    curSpeed, 

                    ((DestCell.GetComponent<Cell>().scaleCoef - CurCell.GetComponent<Cell>().scaleCoef) * playerGlobalScale).magnitude
                    / Vector2.Distance(CurCell.transform.position, DestCell.transform.position)
                    * curSpeed);
            }
        }
    }
}
