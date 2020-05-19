using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnitScriptableObject", order = 1)]
public class UnitScriptableObject : ScriptableObject
{
    public string Unitname;
    public int health;
    public int attackStat;
    
    
    
    public void DealDamage(UnitScriptableObject target)
    {
        target.health -= attackStat;
    }
}
