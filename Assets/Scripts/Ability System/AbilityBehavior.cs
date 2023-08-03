using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using behaviorTypes;
using System.ComponentModel;
using System.Diagnostics;

public class AbilityBehavior : MonoBehaviour
{
    /*
        Damaging: does damage.
        Healing: heals.
        Buff: improves a stat.
        Debuff: lowers a stat.
        Shielding: Protects from an effect.
        Defending: Reduces damage.
        Redirecting: Moves the effect on an effect from one to another.
        Stun: Reduces momentum
    */

    /*
        OnHit: When the ability hits
        WhenHit: Activates on the target the next time they're hit
        OnTurnStart: Activates at the start of a new turn
        OnEndTurn: Activates at the end of a turn
        NewRound: Activates at the start of a new round
     */

    

    public float amount; //Amount of damage, healing, buffing, etc.
    public int duration; //Number of times this behavior acts
    public float chance; //Chance the ability goes off.

    public behaviorType theType;
    public goesOn phase;

    public behaviorType getType() { return theType; }
    public goesOn getPhase() { return phase; }
    public float getAmount() { return amount; }
    public int getDuration() { return duration; }
    public float getChance() { return chance; }

    public void effectsTrigger(CharacterSheet target)
    {
        //Costs have already been paid and validity checked.
        //Switch statement based on the ability's type
        switch (theType)
        {
            case behaviorType.Damaging:
                doDamage(target);
                break;
            case behaviorType.Healing:
                doHealing(target);
                break;
            case behaviorType.Buffing:
                buffStat(target);
                break;
            case behaviorType.Debuffing:
                debuffStat(target);
                break;
            case behaviorType.Shielding:
                createShield(target);
                break;
            case behaviorType.Defending:
                defending(target);
                break;
            case behaviorType.Redirecting:
                redirect(target);
                break;
            case behaviorType.Stun:
                stun(target);
                break;
            default:
                UnityEngine.Debug.Log("Behavior type not recognized.");
                break;
        }
    }
}



namespace behaviorTypes
{
    public enum behaviorType { Damaging, Healing, Buffing, Debuffing, Shielding, Defending, Redirecting, Stun };
    public enum goesOn { OnHit, WhenHit, OnTurnStart, OnTurnEnd, NewRound };

}
