using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitData : MonoBehaviour
{

    public string unitname;
    public int maxHealth;
    public int currBattleHealth;
    public float attackStat;

    private float atkRange;
    private float damageDone;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void DealDamage(BattleUnitData target)
    {
        atkRange = UnityEngine.Random.Range(60, 100);
        damageDone = Mathf.RoundToInt(attackStat * (atkRange / 100));

        //Debug.Log(atkRange + " " + damageDone + " " + attackStat);
        target.currBattleHealth = (target.currBattleHealth - (int)damageDone);
        //target.currBattleHealth -= attackStat;
    }
}
