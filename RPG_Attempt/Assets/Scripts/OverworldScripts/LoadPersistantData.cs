using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPersistantData : MonoBehaviour
{
    [SerializeField]
    UnitScriptableObject playerData;
    void Start()
    {
        //possible temporary for battle testing
        PersistantData.specialEncounter = false;
        PersistantData.playerTeamCount = 1;
        PersistantData.player = playerData;
    }


    void Update()
    {
        
    }
}
