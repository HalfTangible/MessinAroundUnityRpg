using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheet : MonoBehaviour
{

    //We need all of our character's stats.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public string name;
    public int level; //Determines power and helps determine the window where a character can Overwhelm another
    public int momentumStart; //Amount of momentum a character starts with
    public int momentum; //Current momentum
    public int motive; //Amount of momentum a character gains each turn

    //Current health and maximum health

    public int health; //Health. If it hits 0 you die.
    public int maxHealth; //Maximum health

    //Physical stats
    public int strength; //Physical attack stat
    public int defense; //Reduces damage from physical attacks

    //Magical stats
    public int magic; //Enhances offensive spells
    public int warding; //Reduces damage from magical attacks

    //Skill stats
    public int skill; //Enhances skill attacks
    public int wits; //Reduces damage from skill attacks

    /*
     Is it worth considering making strength, magic, and agility also determine things like your health, mana, and skill?
     */

    public List<Ability> abilityList;

    // Update is called once per frame
    /*
    void Update()
    {
        
    }*/
    /*
    public string getName
    {
        get { return name; }
    }*/

    public string getName()
    {
        return name;
    }

    public int getHealth()
    {
        return health;
    }

    public int getMomentum()
    {
        return momentum;
    }

    public void addAbility(Ability newAbility)
    {
        abilityList.Add(newAbility);
    }

    public void addAbility(List<Ability> newAbilityList)
    {
        foreach (var newAbility in newAbilityList)
        {
            addAbility(newAbility);
        }
    }

    public void spendMomentum(int amount)
    {
        momentum -= amount;
    }

    public List<Ability> getAbilities()
    {
        return abilityList;
    }
    
    
}
