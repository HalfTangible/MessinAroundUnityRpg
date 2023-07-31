using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    ArrayList<AbilityBehavior> behaviors;

    // Start is called before the first frame update
    void Start()
    {
        behaviors = new ArrayList<AbilityBehavior>();
    }

    public bool useAbility(CharacterSheet user, CharacterSheet target)
    {

    }
}
