using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public enum battleGameState
    {
        Initialize,
        UnitTurn,
        DamageCalc,
        EndBattle
    }
    public battleGameState battleState;
    // Start is called before the first frame update
    void Start()
    {
        battleState = battleGameState.Initialize;
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleState)
        {
            case battleGameState.Initialize:
                if (!PersistantData.specialEncounter)
                {

                }
                break;
            case battleGameState.UnitTurn:
                break;
            case battleGameState.DamageCalc:
                break;
            case battleGameState.EndBattle:
                break;
            default:
                break;
        }

    }
}
