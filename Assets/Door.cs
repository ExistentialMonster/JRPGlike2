using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractableObject
{

    [SerializeField] int othersideSceneNumber;
    [SerializeField] int spawnNumber;
    [SerializeField] public GameObject CurCell;
    ManagerPlayer player;

    void Start()
    {
        player = FindFirstObjectByType<ManagerPlayer>();
        CurCell.GetComponent<Cell>().accupated = true;
        CurCell.GetComponent<Cell>().UsedBy = gameObject;

    }

    public void UseObject()
    {
        player.speed = 1;
        MetaData.spawnNumber = spawnNumber;
        SceneManager.LoadScene(othersideSceneNumber, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
