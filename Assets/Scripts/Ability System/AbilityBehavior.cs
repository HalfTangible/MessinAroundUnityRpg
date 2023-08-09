using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using behaviorTypes;
using System.ComponentModel;
using System.Diagnostics;

[System.Serializable]
public class AbilityBehavior
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

    public behaviorType theType;
    public goesOn phase;

    public int amount; //Amount of damage, healing, buffing, etc.
    public int duration; //Number of times this behavior acts
    public float chance; //Chance the ability goes off.

    

    public behaviorType getType() { return theType; }
    public goesOn getPhase() { return phase; }
    public float getAmount() { return amount; }
    public int getDuration() { return duration; }
    public float getChance() { return chance; }

    public virtual void Trigger(CharacterSheet target)
    {
        //Costs have already been paid and validity checked.
        //Switch statement based on the ability's type
        
        switch (theType)
        {
            case behaviorType.Damaging:
                DoDamage(target);
                break;
            case behaviorType.Healing:
                DoHealing(target);
                break;
            case behaviorType.Buffing:
                BuffStat(target);
                break;
            case behaviorType.Debuffing:
                DebuffStat(target);
                break;
            case behaviorType.Shielding:
                CreateShield(target);
                break;
            case behaviorType.Defending:
                Defending(target);
                break;
            case behaviorType.Redirecting:
                Redirect(target);
                break;
            case behaviorType.Stun:
                Stun(target);
                break;
            default:
                UnityEngine.Debug.Log("Behavior type not recognized.");
                break;
        }
    }
    
    //This can't be the easiest/cleanest way to do this.
    //Let's do inheritance for AbilityBehavior instead.

    public void DoDamage(CharacterSheet target)
    {

    }
    public void DoHealing(CharacterSheet target)
    {

    }
    public void BuffStat(CharacterSheet target)
    {

    }
    public void DebuffStat(CharacterSheet target)
    {

    }
    public void CreateShield(CharacterSheet target)
    {

    }
    public void Defending(CharacterSheet target)
    {

    }
    public void Redirect(CharacterSheet target)
    {

    }
    public void Stun(CharacterSheet target)
    {

    }

}



namespace behaviorTypes
{
    public enum behaviorType { Damaging, Healing, Buffing, Debuffing, Shielding, Defending, Redirecting, Stun };
    public enum goesOn { OnHit, WhenHit, OnTurnStart, OnTurnEnd, NewRound };
    public enum statToBuff { strength, defense }
}
