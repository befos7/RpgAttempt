using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBattle : MonoBehaviour
{
    //[SerializeField] // future use
    //int fleePercentage;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FleeBattle()
    {
        SceneManager.LoadScene(PersistantData.sceneValue) ;
    }
}
