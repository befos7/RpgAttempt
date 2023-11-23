using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private BattleUnitData[] allyTeam, enemyTeam;
    [SerializeField]
    public BattleUnitData activeUnit;
    [SerializeField]
    public GameObject[] playerSprites, enemySprites;
    [SerializeField]
    public UnitScriptableObject enemyScriptables;
    [SerializeField]
    private Transform[] enemyTransforms;

    


    private int randomMob;
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


    public enum CombatAbilities
    {
        Attack,
        Cleave,
        Heavy,
        Boulder,
        Bleed
    }
    public CombatAbilities abilities;
    // Start is called before the first frame update
    void Start()
    {


        battleState = battleGameState.Standby;
        abilities = CombatAbilities.Attack;
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
        if (PersistantData.TalentPoints[0,6])
        {
            allyTeam[0].lifeSteal = true;
            allyTeam[0].lifeStealPerc = 0.1f;

        }
        //set up the array according to how many mobs i need.
        //this will need to eventually be random of 1-max count
        enemyTeam = new BattleUnitData[PersistantData.maxMobCount]; 
        //enemyTeam[0] = enemySprites[0].GetComponent<BattleUnitData>();
        //enemyTeam[0].unitname = enemyScriptables.unitname;
        //enemyTeam[0].unitIsAlly = false;
        //enemyTeam[0].maxHealth = enemyScriptables.maxHealth;
        //enemyTeam[0].currBattleHealth = enemyScriptables.currBattleHealth;
        //enemyTeam[0].attackStat = enemyScriptables.attackStat;


        //randomMob = Random.Range(0, )
        //the zeros here currently are for testing and should be random to match up with the zone spawn list
        for (int i = 0; i < PersistantData.maxMobCount; i++) 
        {
            GameObject unitSpawn = Instantiate(PersistantData.zoneMobs[0].prefab);
            unitSpawn.transform.position = enemyTransforms[i].position;
            unitSpawn.transform.parent = enemyTransforms[i];
            enemyTeam[i] = unitSpawn.GetComponentInChildren<BattleUnitData>();
            enemyTeam[i].unitname = PersistantData.zoneMobs[0].unitname;
            enemyTeam[i].unitIsAlly = false;
            enemyTeam[i].maxHealth = PersistantData.zoneMobs[0].maxHealth;
            enemyTeam[i].currBattleHealth = PersistantData.zoneMobs[0].currBattleHealth;
            enemyTeam[i].attackStat = PersistantData.zoneMobs[0].attackStat;
        }
        

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



                switch (abilities)
                {
                    case CombatAbilities.Attack:  //1
                        if (activeUnit == enemyTeam[0])
                        {
                            activeUnit.DealDamage(allyTeam[0]);
                            GetComponent<CombatMenuController>().UpdateUnitUIHealth(allyTeam[0].currBattleHealth);
                        }
                        else
                        {
                        activeUnit.DealDamage(enemyTeam[targetIndex]);

                        }

                        break;
                    case CombatAbilities.Cleave:  //2  hit all enemies, costs health
                        for (int i = 0; i < enemyTeam.Length; i++)
                        {
                            activeUnit.DealSetDamage(enemyTeam[i], activeUnit.attackStat); //currently no animations
                        }
                        break;
                    case CombatAbilities.Heavy: //3
                        break;
                    case CombatAbilities.Boulder://4
                        break;
                    case CombatAbilities.Bleed://5

                        //code this later, need to make debuffs

                        break;
                    default:
                        break;
                }
                GoToAnimation();

                //this needs to become based on turn order
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
     public void UpdatePlayerData()
    {
        PersistantData.player.currBattleHealth = allyTeam[0].currBattleHealth;
    }

    public void SetCombatType(int value)
    {
        switch (value)
        {
            case 1:
                abilities = CombatAbilities.Attack;
                break;
            case 2:
                abilities = CombatAbilities.Cleave;
                break;
            case 3:
                abilities = CombatAbilities.Heavy;
                break;
            case 4:
                abilities = CombatAbilities.Boulder;
                break;
            case 5:
                abilities = CombatAbilities.Bleed;
                break;
            default:
                break;
        }
    }
}
