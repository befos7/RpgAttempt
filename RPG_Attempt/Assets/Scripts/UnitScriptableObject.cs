using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnitScriptableObject", order = 1)]
public class UnitScriptableObject : ScriptableObject
{
    public string Unitname;
    public int maxHealth;
    public int currBattleHealth;
    public float attackStat;

    private float atkRange;
    private float damageDone;
    public void DealDamage(UnitScriptableObject target)
    {
        atkRange = UnityEngine.Random.Range(60, 100);
        damageDone = Mathf.RoundToInt(attackStat * (atkRange / 100));

        //Debug.Log(atkRange + " " + damageDone + " " + attackStat);
        target.currBattleHealth = (target.currBattleHealth - (int) damageDone);
        //target.currBattleHealth -= attackStat;
    }
}
