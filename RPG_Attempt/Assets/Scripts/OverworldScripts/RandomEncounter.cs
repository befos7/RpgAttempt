using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounter : MonoBehaviour
{

    [SerializeField]
    public GameObject player;
    int encounterChance;
    int upperEncounterValue;
    int EncounterDecriment;
    // Start is called before the first frame update
    void Start()
    {
        upperEncounterValue = 1000;
        EncounterDecriment = 0;
    }

    
    private void FixedUpdate()
    {
        if (player.GetComponent<PlayerMovement>().playerIsMoving)
        {
            encounterChance = Random.Range(1, upperEncounterValue - EncounterDecriment);
            if (encounterChance == 2)
            {
                PersistantData.sceneValue = SceneManager.GetActiveScene().buildIndex;
                PersistantData.playerLocation = player.transform.position;
                PersistantData.locationSaved = true;
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
        PersistantData.sceneValue = SceneManager.GetActiveScene().buildIndex;
        PersistantData.playerLocation = player.transform.localPosition;
        PersistantData.locationSaved = true;

        SceneManager.LoadScene(2);

    }
}
