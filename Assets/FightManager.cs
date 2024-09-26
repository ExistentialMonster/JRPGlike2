using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    [SerializeField] public int[] fights;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFight(int id)
    {
        SceneManager.LoadSceneAsync(id);
        SceneManager.UnloadSceneAsync(fights[id]);
    }
}
