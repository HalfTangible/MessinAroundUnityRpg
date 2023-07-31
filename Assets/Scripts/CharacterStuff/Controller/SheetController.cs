using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SheetController : MonoBehaviour
{

    //public CharacterSheet sheet;

    //make it a Singleton

    public static SheetController sheetController;
    void Awake() => sheetController = this;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Boolean isOverwhelming(CharacterSheet attacker, CharacterSheet defender)
    {
        int checking = attacker.skill + attacker.momentum - (defender.skill * 2 + defender.momentum);

        if (checking > 0)
            return true;
        //else if(checking <= 0)

        return false;

    }

    public static CharacterSheet doDamage(CharacterSheet c, int damage) {

        c.health -= damage;

        if (c.health < 0)
            c.health = 0;
        

        //If health is at 0, the unit dies and cannot act any further until revived

        return c;

    }

    private static CharacterSheet heal(int healing, CharacterSheet c)
    {

        c.health += healing;

        if (c.health > c.maxHealth)
            c.health = c.maxHealth;

        return c;
    }

    private static CharacterSheet spendMomentum(int momentum, CharacterSheet c)
    {
        c.momentum -= momentum;

        return c;
    }

    private static CharacterSheet regainMomentum(CharacterSheet c, int amount)
    {
        c.momentum += amount;

        return c;
    }

    public static CharacterSheet newRound(CharacterSheet c) {
        return regainMomentum(c, c.motive);
    }

    public static CharacterSheet[] BattleStart(CharacterSheet[] sheets)
    {

        for (int i = 0; i < sheets.Length; i++)
        {
            sheets[i] = SheetController.BattleStart(sheets[i]);
        }

        //Now sort them so that they're in the proper order.
        
        return PartyController.sortSheets(sheets);
    }


    public static CharacterSheet BattleStart(CharacterSheet c)
    {
        c.momentum = c.momentumStart;

        return c;
    }

    //Puts dead at the end of the array
    public static CharacterSheet[] RemoveDead(CharacterSheet[] sheets)
    {
        CharacterSheet temp;

        for (int i = 0; i < sheets.Length; i++)
        {
            if (sheets[i].health == 0)
            {
                temp = sheets[i];
                sheets[i] = sheets[i - 1];
                sheets[i - 1] = temp;
            }

        }

        return sheets;
    }

    //Sorts entire sheet.
    

    //Puts sheet back into the proper spot in the array but doesn't sort the entire array.
    //This probably doesn't work or serve any real purpose?
    //It does, actually; at the end of each turn you can do this again. It'll go faster than sorting the entire array.
    //Would preclude any ability that lowers/raises anyone's Momentum, unless that ability also sorted the party

    public static CharacterSheet[] replaceSheet(CharacterSheet[] party)
    {
       
        
        if (party[0].momentum >= party[1].momentum)
        {
            //If my momentum is > or equal to the next member, I get to act again

            return party;

            /*temp = party[1]; //0 and 1
            party[1] = party[0]; //0 and 0
            party[0] = temp; //0 and 1

            //Alice 12, Bill 12, Casey 11
            //Alice just acted
            //Alice == Bill, swap them
            //Bill 12, Alice 12, Casey 11*/
        }

        CharacterSheet temp;

        for (int i = 1; i < party.Length; i++) {
            if (party[i - 1].momentum <= party[i].momentum)
            {
                temp = party[i]; //0 and 1
                party[i] = party[i-1]; //0 and 0
                party[i-1] = temp; //0 and 1
                                   //If 0 has less momentum than the next in line, swap and then keep going.

                //Bill 12, Alice 12, Casey 11
                //i = 1
                //Bill (0) == Alice(1)
                //Does not swap
                //Breaks

                //If the sheet reaches someone with equal momentum, keep going?
                //If I keep going the whole time then it'll swap every time someone acts and gets sorted back in, right?
                //No, just every time someone hits the same Momentum. And it'll put them at the end.
                //Since this is only sending one guy through, he should go to the very end.
                //Less than or equal to, then.

            }
            else {
                break;
            }
        }

        return party;
    }
}
