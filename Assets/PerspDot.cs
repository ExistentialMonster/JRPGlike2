using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspDot : MonoBehaviour
{
    [SerializeField] public float ScaleMultCoef;
    [SerializeField] public GameObject[] DirCellVecs;
    [SerializeField] public int perspDotId;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.1f);
        for (int i = 0; i < DirCellVecs.Length; i++)
        {
            Gizmos.DrawLine(transform.position, DirCellVecs[i].transform.position + (DirCellVecs[i].transform.position - transform.position) * 10);
        }
    }
}
