using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveProcession : MonoBehaviour
{
    [SerializeField] GameObject? DotPerpective1;
    [SerializeField] GameObject? DotPerpective2;
    [SerializeField] float dotCoef1;
    [SerializeField] float dotCoef2;
    [SerializeField] float baseCoef = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GenScaleCoef(Vector2 cellPos)
    {
        if (DotPerpective1 != null | DotPerpective2 != null)
        {
            float dist1 = Vector2.Distance(cellPos, DotPerpective1.transform.position);
            float dist2 = Vector2.Distance(cellPos, DotPerpective2.transform.position);
            return (dist1 * dotCoef1 + dist2 * dotCoef1) / 10 * baseCoef;
        }
        else
        {
            return baseCoef;
        }
    }
}
