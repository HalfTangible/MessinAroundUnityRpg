using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

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
}

public class CombatStateMachine : MonoBehaviour
{
    public phase currentPhase;
    bool playerCanAct;
    int currentRound;
    bool playerActedLast;

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
        currentRound = 0;

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

        //newRound();
        yield return new WaitForSeconds(2f);

        if (playerParty[0].getMomentum() >= enemyParty[0].getMomentum())
            playerTurn();
        else if (playerParty[0].getMomentum() < enemyParty[0].getMomentum())
            enemyTurn();
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
        ability.Perform(user, target);
    }

    void playerTurn()
    {
        UnityEngine.Debug.Log("playerTurn method!");
        currentPhase = phase.playerTurn;
        playerCanAct = true;

        List<Ability> availableActions = playerParty[0].getAbilities();

        //Get the player's input on what the next action to take with a character is.

        enemyParty[0].health -= 20;

        foreach (var player in playerParty)
        {
            UnityEngine.Debug.Log("playerturn: Player: " + player.getName() + ", health: " + player.getHealth() + ", momentum: " + player.getMomentum());
        }

        playerParty[0].momentum -= 5;
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
        playerActedLast = true;

        PartyController.sortSheets(playerParty);

        nextTurn();
    }

    void enemyTurn()
    {
        UnityEngine.Debug.Log("enemyTurn method!");
        currentPhase = phase.enemyTurn;
        //Decide on an action for the enemy.
        //Perform the action
        playerParty[0].health -= 4;
        enemyParty[0].momentum -= 5;
        //start a new turn
        currentPhase = phase.newTurn;
        playerActedLast = false;
        PartyController.sortSheets(enemyParty);

        nextTurn();
    }

    void nextTurn()
    {
        UnityEngine.Debug.Log("nextTurn method!");
        UnityEngine.Debug.Log("Start of turn: ");
        showBothParties();
        UnityEngine.Debug.Log("End of turn status");


        //Debug purposes
        //enemyTurn();

        //If the next character in a party is dead, sort them again.
        //If they're still dead, that means the fight is over and either the player or the enemy has won

        if (currentPhase == phase.playerTurn)
        {
            //Check the enemies. If they're dead, sort them one more time and check if they're still dead.
            if (PartyController.isBeaten(enemyParty))
            {
                enemyLoses();
                return;
            }
        }
        else if (currentPhase == phase.enemyTurn)
        {
            if (PartyController.isBeaten(playerParty))
            {
                playerLoses();
                return;
            }
        }


        currentPhase = phase.newTurn;

        //See who goes next and send them to act next.

        //Keep player and enemy parties separate. That way you can sort a smaller number of characters each turn and only compare the top of each queue.

        int nextPlayer = playerParty[0].getMomentum();
        int nextFoe = enemyParty[0].getMomentum();

        if (nextPlayer <= 0 && nextFoe <= 0)
            newRound();
        else if (nextPlayer == nextFoe)
        {
            if (playerActedLast)
                playerTurn();
            else if (!playerActedLast)
                enemyTurn();
        }
        else if (nextPlayer < nextFoe)
            enemyTurn();
        else if (nextPlayer > nextFoe)
            playerTurn();

        //Check both the player and the enemy to see if they're done


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
        UnityEngine.Debug.Log("newRound method!");

        currentRound++;

        PartyController.newRound(playerParty, enemyParty);

        //All units have their Momentum refreshed by their growth stat (motive?)
        //Then have both parties sort their queues.

        nextTurn();
    }

    void showBothParties()
    {
        UnityEngine.Debug.Log("showBothParties method!");
        foreach (var player in playerParty)
        {
            UnityEngine.Debug.Log("Player: " + player.getName() + ", health: " + player.getHealth());
        }

        foreach (var enemy in enemyParty)
        {
            UnityEngine.Debug.Log("Enemy: " + enemy.getName() + ", health: " + enemy.getHealth());
        }


    }

    void enemyLoses()
    {
        UnityEngine.Debug.Log("enemyLoses method!");
        showBothParties();
    }

    void playerLoses()
    {
        UnityEngine.Debug.Log("playerLoses method!");
        showBothParties();
    }
}