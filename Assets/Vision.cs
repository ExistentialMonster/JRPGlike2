using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayerToCell(Vector2 point, float scaleCoef, Vector2 globalPlayerScale, float moveSpeed, float scaleSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, point, moveSpeed * Time.deltaTime);
        transform.localScale = Vector2.MoveTowards(transform.localScale, scaleCoef * globalPlayerScale, scaleSpeed * Time.deltaTime);
    }
}
