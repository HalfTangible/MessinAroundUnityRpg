using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{

    public static CharacterSheet[] BattleStart(CharacterSheet[] sheets)
    {
        //Set up the battle round
        /*(for(int i = 0; i < sheets.Length; i++)
        {
            sheets[i] = SheetController.BattleStart(sheets[i]);
        }*/
        return SheetController.BattleStart(sheets);
    }

    public static CharacterSheet[] getPartySheets(GameObject theParty)
    {
        //Each CharacterSheet object needs to be sorted based on which one is next.
        CharacterSheet[] theArray = theParty.GetComponentsInChildren<CharacterSheet>();

        return sortSheets(theArray);
    }

    public static void newRound(CharacterSheet[] a, CharacterSheet[] b)
    {
        newRound(a);
        newRound(b);
    }

    public static void newRound(CharacterSheet[] theParty)
    {
        //Refresh everyone's momentum based on their motive stat (unless they're dead, in which case set their momentum to 0).


        //CharacterSheet[] childScripts = this.GetComponentsInChildren<CharacterSheet>();
        /*
        for (int i = 0; i < this.transform.childCount; i++)
        {
            /*
            Finding scripts/components attached to child GameObject:

            If all you want is the script that is attached to the child GameObject, then use GetComponentInChildren:

            MyScript childScript = originalGameObject.GetComponentInChildren<MyScript>();

             
            SheetController.newRound(childScripts[i]);
        }*/

        foreach (var sheet in theParty)
        {
            SheetController.newRound(sheet);
        }

        //Next you need to sort each of them by Momentum.
        sortSheets(theParty);
    }

    public static bool isBeaten(CharacterSheet[] theParty)
    {
        //If any of the sheets are alive, then the match isn't done yet.

        foreach (var sheet in theParty)
        {
            if (sheet.getHealth() > 0)
                return false;
        }

        return true;
    }

    public static CharacterSheet[] sortSheets(CharacterSheet[] sheets)
    {
        //if it's got 4 items
        //0,1,2,3
        //1 and 0, 2 and 1, 3 and 2
        CharacterSheet temp;
        //4 items: 0, 1, 2, 3
        for (int i = 0; i < sheets.Length; i++)
        {
            if (sheets[i].health == 0)
            {
                temp = sheets[i];
                sheets[i] = sheets[i - 1];
                sheets[i - 1] = temp;
            }

        }

        for (int i = 1; i < sheets.Length; i++)
        {

            bool areNotBothDead = (sheets[i - 1].getHealth() != 0 && sheets[i].getHealth() != 0);
            bool momentumIsHigher = (sheets[i].getMomentum() > sheets[i - 1].getMomentum());
            bool isZeroDead = (sheets[i - 1].getHealth() == 0 && sheets[i].getHealth() != 0);

            //If 1 has more momentum than 0, swap so that 1 goes first. Alternatively, if 0 is dead and 1 isn't, swap so that dead units always go to the end. Do not swap if both are dead.
            if (momentumIsHigher || (isZeroDead && areNotBothDead)) //Earlier characters should have more momentum. Later characters should be dead.
            {
                //if sheets[i] has 0 health, sheets[i] gets swapped with sheets[i-1].
                temp = sheets[i];
                sheets[i] = sheets[i - 1];
                sheets[i - 1] = temp;
                //If a swap occurs, then we're not done checking to be sure.
                sheets = sortSheets(sheets);
            }

        }

        return sheets;

    }
}
