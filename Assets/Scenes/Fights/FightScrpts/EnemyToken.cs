using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyToken : MonoBehaviour
{
    bool stunned = false;
    int stunCount = 0;
    int stunTime = 1;
    public string Name = "h";
    public void GetStunned()
    {
        stunned = true;
        Debug.Log(Name + " stunned");
    }
}
