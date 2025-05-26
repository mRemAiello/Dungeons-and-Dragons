public class Barbarian : AdventurerClass
{
    public readonly int DICE_TIMES = 3;
    
    public override int HealthRoll()
    {
        int healthRoll = Dice.RollD12();
        return healthRoll;
    }

    public override int MoneyRoll()
    {
        int moneyRoll = 0;
        for (int i = 0; i < DICE_TIMES; i++)
        {
            moneyRoll += Dice.RollD12();
        }
        return moneyRoll;
    }
}