using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cell : MonoBehaviour
{
    PerspectiveProcession Controller;
    [SerializeField] public float scaleCoef;
    public bool accupated = false;
    public GameObject? UsedBy = null;
    [SerializeField] public GameObject[] NearCells;
    [SerializeField] bool autoScale = true;

    private void Start()
    {
        // Controller = FindObjectOfType<PerspectiveProcession>();
        // if (autoScale)
        // {
        //     scaleCoef = Controller.GenScaleCoef(transform.position);
        // }
    }

    [ContextMenu("SetNearCells")]
    void SetNearCells()
    {
        if (NearCells[0] != null)
        {
            NearCells[0].GetComponent<Cell>().NearCells[2] = gameObject;
        }
        if (NearCells[1] != null)
        {
            NearCells[1].GetComponent<Cell>().NearCells[3] = gameObject;
        }
        if (NearCells[2] != null)
        {
            NearCells[2].GetComponent<Cell>().NearCells[0] = gameObject;
        }
        if (NearCells[3] != null)
        {
            NearCells[3].GetComponent<Cell>().NearCells[1] = gameObject;
        }
    }

    [ContextMenu("SetNearCells2")]

    void SetNearCells2()
    {
        RaycastHit2D nearCell;
        PerspDot[] dots = FindObjectsOfType<PerspDot>();
        if (dots[0].perspDotId == 1)
        {
            dots = new PerspDot[] { dots[1], dots[0] };
        }
        Vector3 dirVec = (dots[0].transform.position - transform.position);
        nearCell = Physics2D.Raycast(transform.position + (GetComponent<CircleCollider2D>().radius + 0.1f) * dirVec.normalized, dirVec, 100);
        if (nearCell)
        {
            nearCell.collider.gameObject.GetComponent<Cell>().NearCells[2] = gameObject;
            Debug.Log("hui");
        }
        dirVec = -(dots[0].transform.position - transform.position);
        nearCell = Physics2D.Raycast(transform.position + (GetComponent<CircleCollider2D>().radius + 0.1f) * dirVec.normalized, dirVec, 100);
        if (nearCell)
        {
            nearCell.collider.gameObject.GetComponent<Cell>().NearCells[0] = gameObject;
            Debug.Log("hui");
        }
        dirVec = -(dots[1].transform.position - transform.position);
        nearCell = Physics2D.Raycast(transform.position + (GetComponent<CircleCollider2D>().radius + 0.1f) * dirVec.normalized, dirVec, 100);
        if (nearCell)
        {
            nearCell.collider.gameObject.GetComponent<Cell>().NearCells[3] = gameObject;
            Debug.Log("hui");
        }
        dirVec = (dots[1].transform.position - transform.position);
        nearCell = Physics2D.Raycast(transform.position + (GetComponent<CircleCollider2D>().radius + 0.1f) * dirVec.normalized, dirVec, 100);
        if (nearCell)
        {
            nearCell.collider.gameObject.GetComponent<Cell>().NearCells[1] = gameObject;
            Debug.Log("hui");
        }
    }

    [ContextMenu("NormalizeByGrid")]
    void NormalizeByGrid()
    {
        PerspDot[] dots = FindObjectsOfType<PerspDot>();
        float minDistance = 200;
        int nearLine1Id = 0;
        for (int i = 0;  i < dots[0].DirCellVecs.Length; i++)
        { 
            if (HandleUtility.DistancePointToLine(transform.position, dots[0].transform.position, dots[0].DirCellVecs[i].transform.position) < minDistance)
            {
                minDistance = HandleUtility.DistancePointToLine(transform.position, dots[0].transform.position, dots[0].DirCellVecs[i].transform.position);
                nearLine1Id = i;
            }
        }
        minDistance = 200;
        int nearLine2Id = 0;
        for (int i = 0; i < dots[1].DirCellVecs.Length; i++)
        {
            if (HandleUtility.DistancePointToLine(transform.position, dots[1].transform.position, dots[1].DirCellVecs[i].transform.position) < minDistance)
            {
                minDistance = HandleUtility.DistancePointToLine(transform.position, dots[1].transform.position, dots[1].DirCellVecs[i].transform.position);
                nearLine2Id = i;
            }
        }
        transform.position = new MathThings().IntersectTwoLines(
                                                                dots[0].transform.position,
                                                                dots[0].DirCellVecs[nearLine1Id].transform.position,
                                                                dots[1].transform.position,
                                                                dots[1].DirCellVecs[nearLine2Id].transform.position
                                                                );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

}
