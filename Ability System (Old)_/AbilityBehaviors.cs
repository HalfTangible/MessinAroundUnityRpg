using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;




public class AbilityBehaviors
{
    //https://www.youtube.com/watch?v=qTyCWz7QBZU


    private BasicInfo basicInfo;
    private BehaviorStartTimes startTime;

    public AbilityBehaviors(BasicInfo basicInfo, BehaviorStartTimes startTime)
    {
        this.basicInfo = basicInfo;
        this.startTime = startTime;
    }
    
    public enum BehaviorStartTimes
    {
        Beginning,
        Middle,
        End
    }

    public virtual void PerformBehavior(ref CharacterSheet user, ref CharacterSheet target)
    {
        //Call this whenever the behavior does whatever it's supposed to do.
        UnityEngine.Debug.LogWarning("An ability triggered but doesn't have a behavior assigned!");
    }

    public BasicInfo getBasicInfo() { 
        return basicInfo;
    }

    public BehaviorStartTimes getBehaviorStartTime() { 
        
            return startTime;
    }

}
