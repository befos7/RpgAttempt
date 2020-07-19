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
    private BattleUnitData target;
    private float slideSpeed = 20f;
    private Vector3 originPosition;
    protected enum AttackMove
    {
        Still,
        Slide,
        Animation,
        SlideBack
    }
    protected AttackMove attackMoveState;
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
        attackMoveState = AttackMove.Slide;

        //target.currBattleHealth -= attackStat;
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
                    DamagePopup.Create(target.transform.position, (int)damageDone);

                }
                break;
            case AttackMove.Animation:
                animator.SetTrigger("Attack");

                attackMoveState = AttackMove.SlideBack;
                break;
            case AttackMove.SlideBack:
                Debug.Log("slideback");
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
}
