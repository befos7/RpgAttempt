using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BattleUnitData : MonoBehaviour
{

    public string unitname;
    public bool unitIsAlly;
    public int maxHealth;
    public int currBattleHealth;
    public float attackStat;

    //passives
    public bool lifeSteal = false; //lifesteal can be 10% right now
    public float lifeStealPerc;
    public float lifeStealAmount;

    private float atkRange;
    private float damageDone;
    private Animator animator;
    private BattleUnitData target;
    private float slideSpeed = 20f;
    private Vector3 originPosition;
    public enum AttackMove
    {
        Still,
        Slide,
        Animation,
        SlideBack
    }
    public AttackMove attackMoveState;
    private void Start()
    {
        animator = GetComponent<Animator>();
        originPosition = this.transform.position;
    }
    public void DealDamage(BattleUnitData atkTarget)
    {
        target = atkTarget;
        atkRange = UnityEngine.Random.Range(60, 100);
        damageDone = Mathf.RoundToInt(attackStat * (atkRange / 100));

        //Debug.Log(atkRange + " " + damageDone + " " + attackStat);
        target.currBattleHealth = (target.currBattleHealth - (int)damageDone);
        if (lifeSteal)
        {
            ApplyLifeSteal(damageDone);
        }
        attackMoveState = AttackMove.Slide;

        //target.currBattleHealth -= attackStat;
    }
    public void ApplyLifeSteal(float damage)
    {
        lifeStealAmount = Mathf.RoundToInt(damage * lifeStealPerc);
        if (lifeStealAmount < 1)
        {
            lifeStealAmount = 1;
        }
        
        currBattleHealth += (int)lifeStealAmount;

        
    }

    private void Update()
    {
        switch (attackMoveState)
        {
            case AttackMove.Still:

                break;
            case AttackMove.Slide:
                transform.Translate((target.transform.position - this.transform.position).normalized * (slideSpeed * Time.fixedDeltaTime));

                if (Vector3.Distance(this.transform.position, target.transform.position) < 2f)
                {
                    attackMoveState = AttackMove.Animation;
                    DamagePopup.Create(target.transform.position, (int)damageDone, Color.red);
                    if (lifeSteal)
                    {
                        DamagePopup.Create(transform.position, (int)lifeStealAmount, Color.green);

                    }

                }
                break;
            case AttackMove.Animation:
                animator.SetTrigger("Attack");

                attackMoveState = AttackMove.SlideBack;
                break;
            case AttackMove.SlideBack:
                
                transform.Translate((originPosition - this.transform.position).normalized * (slideSpeed * Time.fixedDeltaTime));
                if (Vector3.Distance(this.transform.position, originPosition) < 0.1f)
                {
                    attackMoveState = AttackMove.Still;

                }

                break;
            default:
                break;
        }
    }

    public bool UnitAtRest()
    {
        if (attackMoveState == AttackMove.Still)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetUnitHealth()
    {
        return currBattleHealth;
    }
}
