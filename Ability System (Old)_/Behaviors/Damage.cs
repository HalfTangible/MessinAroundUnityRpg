using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Damage : AbilityBehaviors
{
    private const string name = "Damage Behavior";
    private const string desc = "This ability does damage.";
    //public SheetController sheetController;

    private int amountBase;
    //private int momentumCost;

    public Damage(int amount) : base(new BasicInfo(name, desc), BehaviorStartTimes.Beginning)
    {
        this.amountBase = amount;
    }

    public int getAmount
    {
        get { return amountBase; }
    }

/*    public int getMomentumCost
    {
        get { return momentumCost; }
    }
*/
    //https://www.c-sharpcorner.com/article/using-pointers-in-C-Sharp/
    /*
     
     The ampersand '&' is the referencer and means the 'location of'. So if we now do the following in our code:
        int age = 32;
        int* age_ptr;
        age_ptr = &age
        Console.WriteLine("age = {0}", age);
        Console.WriteLine("age_ptr = {0}", *age_ptr);

        We should now see the following output on the console:

        age = 32
        age_ptr = 32
     */

    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref
    /*
     
    To use a ref parameter, both the method definition and the calling method must explicitly use the ref keyword, as shown in the following example. (Except that the calling method can omit ref when making a COM call.)
C#

void Method(ref int refArgument)
{
    refArgument = refArgument + 44;
}

int number = 1;
Method(ref number);
Console.WriteLine(number);
// Output: 45


     */
    public override void PerformBehavior(ref CharacterSheet user, ref CharacterSheet target)
    {
        //Call this whenever the behavior does whatever it's supposed to do.
        //For the current Damage behavior this is very basic but we can override PerformBehavior in later iterations if we want to change the Overwhelm effect.
        //Maybe it'd be best to do Overwhelm in its own method actually...

        UnityEngine.Debug.Log("Damage effect triggers.");
        //Actually, this should be in the Ability behavior rather than the
        //user.momentum -= momentumCost;

        

        if (user.momentum + user.skill > target.momentum + (target.skill * 2))
            Overwhelm(ref user, ref target);
        else
            target.health -= amountBase;
        //sheetController.doDamage(target, amount);
    }

    public void Overwhelm(ref CharacterSheet user, ref CharacterSheet target)
    {
        UnityEngine.Debug.Log("Overwhelming damage effect triggers!");
        int amount = amountBase * 2;
        //Probably need to pass this to SheetController actually, so that that can determine the final amount of damage?
        //As is, this doesn't take defenses into account or anything
        
        target.health -= amount;

    }

}
