using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : AbilityBehavior
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Trigger(CharacterSheet target)
    {
        target.DoDamage(amount);
    }
}
