using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject[] spawnCells;
    [SerializeField] GameObject player;
    void Start()
    {
        Debug.Log(MetaData.spawnNumber);
        player.GetComponent<ManagerPlayer>().CurCell = spawnCells[MetaData.spawnNumber];
        player.GetComponent<ManagerPlayer>().SetCurCell();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
