using System.Collections;
using System.Collections.Generic;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

}
