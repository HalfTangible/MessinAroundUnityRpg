using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using behaviorTypes; //defined in AbilityBehavior

public class Ability : MonoBehaviour
{

    BasicInfo basicInfo;
    List<AbilityBehavior> behaviors;
    public int momentumCost;
    public int manaCost;

    // Start is called before the first frame update
    void Start()
    {
        behaviors = new List<AbilityBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<AbilityBehavior> getAllBehaviors()
    {
        return behaviors;
    }

    public List<AbilityBehavior> getBehaviorsOfType(behaviorType theType)
    {
        List<AbilityBehavior> byType = new List<AbilityBehavior>();

        foreach (AbilityBehavior b in behaviors) {
            if (b.getType() == theType)
                byType.Add(b);
        }

        return byType;
    }

    public bool Perform(CharacterSheet user, CharacterSheet target)
    {
        //Validate the user and target are both valid choices.
        if (user.canUse(this) && target.isValidTarget(this, user)) {
            
            user.uses(this);
            target.isHitBy(this);

            return true;
        }
        else
            return false;
    }


}
