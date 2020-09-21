using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenuController : MonoBehaviour
{

    //attack action currently directly enables the target panel

    [SerializeField]
    GameObject combatPanel;
    [SerializeField]
    UIUnitInfo[] allyUnits;
    

    public void DisableCombatPanel()
    {
        combatPanel.SetActive(false);
    }

    public void EnableCombatPanel()
    {
        combatPanel.SetActive(true);

    }

    
    public void UpdateUnitUIHealth(int health)
    {
        allyUnits[0].UpdateHealth(health);
    }

    public void SetUnitMaxHealth(int healthMax)
    {
        allyUnits[0].UpdateMaxHealth(healthMax);

    }
}
