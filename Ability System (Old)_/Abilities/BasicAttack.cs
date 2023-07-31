using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BasicAttack : Ability
{
    //Does some basic damage.
    //Requires target
    //Attacks enemy
    //Does some damage

    private const string name = "Basic attack";
    private const string desc = "A basic ability that does some damage";
    public int momentumCost;
    //List<AbilityBehaviors> behaviors = new List<AbilityBehaviors>();

    //new BasicInfo("Basic attack", "Does some damage. Not very strong")

    public BasicAttack() : base(name, desc) {
        momentumCost = 4;
        addBehavior(new Damage(6)); //This attack does 6 damage base, 12 on Overwhelm.
    }

    public void Perform(ref CharacterSheet user, ref CharacterSheet target)
    {
        user.spendMomentum(momentumCost);

        foreach (var behavior in AbilityBehaviors)
        {
            behavior.PerformBehavior(ref user, ref target);
        }
    }

}
