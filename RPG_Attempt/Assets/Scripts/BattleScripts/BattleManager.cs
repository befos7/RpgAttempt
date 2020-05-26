using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private BattleUnitData[] allyTeam, enemyTeam;
    [SerializeField]
    GameObject[] playerSprites, enemySprites;
    [SerializeField]
    private UnitScriptableObject enemyScriptables;

    private int targetIndex;
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
        if (PersistantData.playerTeamCount < 1)
        {
            allyTeam = new BattleUnitData[1];

        }
        else
        {
            allyTeam = new BattleUnitData[PersistantData.playerTeamCount];

        }
        allyTeam[0] = playerSprites[0].GetComponent<BattleUnitData>();
        allyTeam[0].unitname = PersistantData.player.unitname;
        allyTeam[0].maxHealth = PersistantData.player.maxHealth;
        allyTeam[0].currBattleHealth = PersistantData.player.currBattleHealth;
        allyTeam[0].attackStat = PersistantData.player.attackStat;
        //allyTeam[0] = PersistantData.player;
        enemyTeam = new BattleUnitData[1];
        enemyTeam[0] = enemySprites[0].GetComponent<BattleUnitData>();
        enemyTeam[0].unitname = enemyScriptables.unitname;
        enemyTeam[0].maxHealth = enemyScriptables.maxHealth;
        enemyTeam[0].currBattleHealth = enemyScriptables.currBattleHealth;
        enemyTeam[0].attackStat = enemyScriptables.attackStat;

        foreach (BattleUnitData item in enemyTeam)
        {
            item.currBattleHealth = item.maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleState)
        {
            case battleGameState.Initialize:// I dont actually know what thise section is for. I hope it comes in handy at some point
                if (!PersistantData.specialEncounter)
                {

                }
                break;
            case battleGameState.UnitTurn:
                break;
            case battleGameState.DamageCalc:

                //this needs to become based on turn order
                allyTeam[0].DealDamage(enemyTeam[targetIndex]);
                if (enemyTeam[0].currBattleHealth <= 0)
                {
                    GoToEndBattle();
                }
                else
                {
                    GoToUnitTurn();
                }
                break;
            case battleGameState.EndBattle:
                GetComponent<ExitBattle>().FleeBattle();

                break;
            default:
                break;
        }

    }


    public void ReturnUnitByIndex(int index)
    {
        targetIndex = index;
        GotoDamageCalc();
    }

    public void GotoDamageCalc()
    {
        battleState = battleGameState.DamageCalc;
    }
    public void GoToEndBattle()
    {
        battleState = battleGameState.EndBattle;

    }
    public void GoToUnitTurn()
    {
        battleState = battleGameState.UnitTurn;
    }
}
