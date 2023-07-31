using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ability
{
    //https://www.youtube.com/watch?v=M7qxcCyZlJ4

    private string name;
    private string description;
    private List<AbilityBehaviors> behaviors;

    //A JRPG ability can be used on:
    //Yourself
    //An enemy
    //An ally
    //Multiple enemies
    //Multiple allies
    //All enemies
    //All allies
    //test

    private bool canCastOnSelf;
    private bool targetsEnemies;
    private bool targetsAllies;
    private bool affectsWholeParty;
    private int maxTargets;

    private int momentumCost;
    private GameObject particleEffect;

    /*
    private AbilityType mainType;
    private AbilityType secondaryType;

    public enum AbilityType
    {
        Skill,
        Magic,
        Strength,
        Basic,
        None
    }*/

    //These constructors might need refactoring as they add a lot of data that we can't modify in subclasses.

    public Ability(string name, string description)
    {
        this.name = name;
        this.behaviors = new List<AbilityBehaviors>();

        this.canCastOnSelf = false;
        this.targetsEnemies = false;
        this.targetsAllies = false;
        this.affectsWholeParty = false;
        this.maxTargets = 0;
        this.description = description; //Work on method later to create a description based on behaviors.

        this.momentumCost = 0;
    }

    public Ability(string name, List<AbilityBehaviors> behaviors) {
        this.name = name;
        this.behaviors = new List<AbilityBehaviors>();
        this.behaviors = behaviors;

        this.canCastOnSelf = false;
        this.targetsEnemies = false;
        this.targetsAllies = false;
        this.affectsWholeParty = false;
        this.maxTargets = 0;
        this.description = "Default"; //Work on method later to create a description based on behaviors.

        this.momentumCost = 0;
    }

    public Ability(string name, string description, List<AbilityBehaviors> behaviors)
    {
        this.name = name;
        this.behaviors = new List<AbilityBehaviors>();
        this.behaviors = behaviors;

        this.canCastOnSelf = false;
        this.targetsEnemies = false;
        this.targetsAllies = false;
        this.affectsWholeParty = false;
        this.maxTargets = 0;
        this.description = description; //Work on method later to create a description based on behaviors.

        this.momentumCost = 0;
    }

    public void Perform(ref CharacterSheet user, ref CharacterSheet target)
    {
        foreach (var behavior in behaviors)
        {
            behavior.PerformBehavior(ref user, ref target);
        }
    }

    public string AbilityName
    {
        get
        {
            return this.name;
        }
    }

    public List<AbilityBehaviors> AbilityBehaviors
    {
        get
        {
            return this.behaviors;
        }
    }

    public void addBehavior(AbilityBehaviors newbehavior)
    {
        behaviors.Add(newbehavior);
    }

    public bool CanCastOnSelf
    {
        get
        {
            return this.canCastOnSelf;
        }
    }

    public bool TargetsEnemies
    {
        get
        {
            return this.targetsEnemies;
        }
    }

    public bool TargetsAllies
    {
        get
        {
            return this.targetsAllies;
        }
    }

    public bool AffectsParty
    {
        get
        {
            return this.affectsWholeParty;
        }
    }

    public int MaxTargets
    {
        get
        {
            return this.maxTargets;
        }
    }

    public string AbilityDesc
    {
        get
        {
            return this.description;
        }


    }


}