using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounter : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    int encounterChance;
    int upperEncounterValue;
    int EncounterDecriment;
    // Start is called before the first frame update
    void Start()
    {
        upperEncounterValue = 2000;
        EncounterDecriment = 0;
    }

    
    private void FixedUpdate()
    {
        if (player.GetComponent<PlayerMovement>().playerIsMoving)
        {
            encounterChance = Random.Range(1, upperEncounterValue - EncounterDecriment);
            if (encounterChance == 2)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                if (upperEncounterValue - EncounterDecriment > 50)
                {
                EncounterDecriment++;

                }
            }
        }
        //Debug.Log(encounterChance + " " + EncounterDecriment);
    }

    public void StartRandomBattle()
    {
        SceneManager.LoadScene(2);

    }
}
