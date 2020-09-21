using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private BattleUnitData[] allyTeam, enemyTeam;
    [SerializeField]
    private BattleUnitData activeUnit;
    [SerializeField]
    GameObject[] playerSprites, enemySprites;
    [SerializeField]
    private UnitScriptableObject enemyScriptables;
    
    
    

    private int targetIndex;
    public enum battleGameState
    {
        Standby,
        UnitTurn,
        DamageCalc,
        AnimationTime,
        EndTurn
    }
    public battleGameState battleState;
    // Start is called before the first frame update
    void Start()
    {


        battleState = battleGameState.Standby;
        if (PersistantData.playerTeamCount < 1)
        {
            allyTeam = new BattleUnitData[1];

        }
        else
        {
            allyTeam = new BattleUnitData[PersistantData.playerTeamCount];

        }

        //pass data into the units

        allyTeam[0] = playerSprites[0].GetComponent<BattleUnitData>();
        allyTeam[0].unitname = PersistantData.player.unitname;
        allyTeam[0].unitIsAlly = true;
        allyTeam[0].maxHealth = PersistantData.player.maxHealth;
        allyTeam[0].currBattleHealth = PersistantData.player.currBattleHealth;
        allyTeam[0].attackStat = PersistantData.player.attackStat;

        enemyTeam = new BattleUnitData[1];
        enemyTeam[0] = enemySprites[0].GetComponent<BattleUnitData>();
        enemyTeam[0].unitname = enemyScriptables.unitname;
        enemyTeam[0].unitIsAlly = false;
        enemyTeam[0].maxHealth = enemyScriptables.maxHealth;
        enemyTeam[0].currBattleHealth = enemyScriptables.currBattleHealth;
        enemyTeam[0].attackStat = enemyScriptables.attackStat;

        // update ui with info
        //this needs to be a new method eventually

        SetInitialValues();

        foreach (BattleUnitData item in enemyTeam)
        {
            item.currBattleHealth = item.maxHealth;
        }




        ////For testing
        activeUnit = allyTeam[0];
        /////
        ////
        ////
        ////
        ////
        ////
        ///
    }

    private void SetInitialValues()
    {
        GetComponent<CombatMenuController>().UpdateUnitUIHealth(allyTeam[0].currBattleHealth);
        GetComponent<CombatMenuController>().SetUnitMaxHealth(allyTeam[0].maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleState)
        {
            case battleGameState.Standby:// This phase can handle debuffs
                if (activeUnit.attackMoveState == BattleUnitData.AttackMove.Still)
                {
                    GoToUnitTurn();
                    
                }
                break;
            case battleGameState.UnitTurn:
                //choose target, and start animate attack then move to damagecalc
                if (activeUnit == enemyTeam[0])
                {
                    GotoDamageCalc();
                }

                
                break;
            case battleGameState.DamageCalc:

                //this needs to become based on turn order
                if (activeUnit == enemyTeam[0])
                {
                    activeUnit.DealDamage(allyTeam[0]);
                    GetComponent<CombatMenuController>().UpdateUnitUIHealth(allyTeam[0].currBattleHealth);
                }
                else
                {
                activeUnit.DealDamage(enemyTeam[targetIndex]);

                }
                GoToAnimation();
                break;
            case battleGameState.AnimationTime:
                if (activeUnit.attackMoveState == BattleUnitData.AttackMove.Still)
                {
                    GoToEndBattle();
                }
                break;
            case battleGameState.EndTurn:

                if (enemyTeam[0].currBattleHealth <= 0)
                {
                    UpdatePlayerData();
                    GetComponent<ExitBattle>().FleeBattle();

                }
                else
                {
                    NextTurnOrder();
                    GotoStandby();

                }

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
        GetComponent<CombatMenuController>().DisableCombatPanel();

        battleState = battleGameState.DamageCalc;
    }
    public void GoToEndBattle()
    {
        battleState = battleGameState.EndTurn;

    }
    public void GoToUnitTurn()
    {
        if (activeUnit.unitIsAlly)
        {
        GetComponent<CombatMenuController>().EnableCombatPanel();

        }

        battleState = battleGameState.UnitTurn;
    }
    public void GotoStandby()
    {
       
        battleState = battleGameState.Standby;

    }
    public void GoToAnimation()
    {
        battleState = battleGameState.AnimationTime;
    }

    private void NextTurnOrder()
    {
        //only two units as of now, need to change for full parties
        if (activeUnit == allyTeam[0])
        {
            activeUnit = enemyTeam[0];
        }
        else
        {
            activeUnit = allyTeam[0];

        }
    }
     private void UpdatePlayerData()
    {
        PersistantData.player.currBattleHealth = allyTeam[0].currBattleHealth;
    }
}
