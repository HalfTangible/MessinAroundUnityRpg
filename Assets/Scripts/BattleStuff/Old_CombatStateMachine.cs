using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

/*
public enum phase
{
    start,
    playerTurn,
    enemyTurn,
    newRound,
    newTurn,
    victory,
    defeat,
    cutscene
}*/

public class Old_CombatStateMachine : MonoBehaviour
{
    public phase currentPhase;
    bool playerCanAct;
    int currentRound;

    public GameObject playerPartyObj;
    public GameObject enemyPartyObj;

    CharacterSheet[] playerParty;
    CharacterSheet[] enemyParty;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        currentPhase = phase.start;
        playerCanAct = false;
        currentRound = 0;
        sentences = new Queue<string>();
        playerPartyObj = GameObject.Find("PlayerParty");
        enemyPartyObj = GameObject.Find("EnemyParty");
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle() //Coroutine; allows us to wait for a time, or for input from the player.
    {
        currentRound = 1;

        playerParty = PartyController.getPartySheets(playerPartyObj);
        enemyParty = PartyController.getPartySheets(enemyPartyObj);

        SheetController.BattleStart(playerParty);
        SheetController.BattleStart(enemyParty);

        foreach (var player in playerParty)
        {
            UnityEngine.Debug.Log("Player: " + player.getName() + ", health: " + player.getHealth());
        }

        foreach (var enemy in enemyParty)
        {
            UnityEngine.Debug.Log("Enemy: " + enemy.getName() + ", health: " + enemy.getHealth());
            //string sentence = "An enemy " + enemy.getName + " approaches!";
            //sentences.Enqueue(sentence);
        }


        //Display all dialogue for the enemy.

        playerTurn();

        yield return new WaitForSeconds(2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void useAbility(ref CharacterSheet user, ref CharacterSheet target, ref Ability ability)
    {
        UnityEngine.Debug.Log("useAbility method!");
        //Can the user use the ability?
        //Determine that before this point, actually.
        ability.Perform(ref user, ref target);
    }

    void playerTurn()
    {
        UnityEngine.Debug.Log("playerTurn method!");
        currentPhase = phase.playerTurn;
        playerCanAct = true;

        List<Ability> availableActions = playerParty[0].getAbilities();

        //Get the player's input on what the next action to take with a character is.

        //playerParty[0].health -= 20;

        foreach (var player in playerParty)
        {
            UnityEngine.Debug.Log("playerturn: Player: " + player.getName() + ", health: " + player.getHealth() + ", momentum: " + player.getMomentum());
        }

        playerParty[0].momentum -= 25;
        PartyController.sortSheets(playerParty);

        UnityEngine.Debug.Log("After Momentum in playerturn: Player 0: " + playerParty[0].getName() + ", health: " + playerParty[0].getHealth() + ", momentum: " + playerParty[0].getMomentum());


        foreach (var player in playerParty)
        {
            UnityEngine.Debug.Log("playerturn: Player: " + player.getName() + ", health: " + player.getHealth() + ", momentum: " + player.getMomentum());
        }



        //playerParty = PartyController.sortParty(playerPartyObj);

        foreach (var player in playerParty)
        {
            UnityEngine.Debug.Log("IN OBJECT playerturn: Player: " + player.getName() + ", health: " + player.getHealth());
        }
        /*
        foreach (var enemy in enemyParty)
        {
            UnityEngine.Debug.Log("playerTurn: Enemy: " + enemy.getName() + ", health: " + enemy.getHealth());
        }*/


        /*
         foreach (var ability in availableActions)
        {
        
        //Add it to the display.

        }
         
         */

        while (playerCanAct)
        {
            //Show the UI to get the player's action
            //Once the action is selected, execute it and move on.
            //Make sure the ability and target are both valid before performing the ability.
            //if (targetSelected && abilitySelected)
            playerCanAct = false;
        }

        //Player action is executed.

        //We need to determine when we and the enemy are out of Momentum to act.
        //Also, check if all enemies are dead.
        playerCanAct = false;
        nextTurn();
    }

    void enemyTurn()
    {
        UnityEngine.Debug.Log("enemyTurn method!");
        currentPhase = phase.enemyTurn;
        //Decide on an action for the enemy.
        //Perform the action
        //start a new turn
        currentPhase = phase.newTurn;
    }

    void nextTurn()
    {
        UnityEngine.Debug.Log("nextTurn method!");

        //Debug purposes
        enemyTurn();

        currentPhase = phase.newTurn;


        //See who goes next and send them to act next.


        //Keep player and enemy parties separate. That way you can sort a smaller number of characters each turn and only compare the top of each queue.


        //How do we tell whether a new round starts?


        //Check both the player and the enemy to see if they're done

        //If the next character in a party is dead, sort them again.
        //If they're still dead, that means the fight is over and either the player or the enemy has won

        /*
        if(playerParty.isDone && enemyParty.isDone)
        {
            playerParty.isDone = false;
            enemyParty.isDone = false;
         
            newRound();
        }*/

        /*
        if (playerCanAct)
        {
            currentPhase = phase.playerTurn;
            playerTurn();
        } else
        {
            currentPhase = phase.enemyTurn;
        }
        
        */
    }

    void newRound()
    {
        currentRound++;

        //All units have their Momentum refreshed by their growth stat (motive?)
        //Then have both parties sort their queues.

    }
}
