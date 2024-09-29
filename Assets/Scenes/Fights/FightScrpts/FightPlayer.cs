using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTurn()
    {
        while (Input.GetKeyDown(KeyCode.Space) != true)
        {
        }
        Debug.Log("ahhahant");
        FindObjectOfType<FightControll>().EndPlayerTurn();
    }
}
