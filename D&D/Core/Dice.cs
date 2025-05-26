public class Dice
{
    private static int GetNumber(int number)
    {
        var random = new Random();
        var result = random.Next(1, number + 1);
        return result;
    }

    public static int Roll(DiceValues diceValue)
    {
        return diceValue switch
        {
            DiceValues.D3 => RollD3(),
            DiceValues.D4 => RollD4(),
            DiceValues.D6 => RollD6(),
            DiceValues.D8 => RollD8(),
            DiceValues.D10 => RollD10(),
            DiceValues.D12 => RollD12(),
            DiceValues.D20 => RollD20(),
            _ => throw new ArgumentOutOfRangeException(nameof(diceValue), diceValue, null)
        };
    }

    //
    public static int RollD3() => GetNumber(3);
    public static int RollD4() => GetNumber(4);
    public static int RollD6() => GetNumber(6);
    public static int RollD8() => GetNumber(8);
    public static int RollD10() => GetNumber(10);
    public static int RollD12() => GetNumber(12);
    public static int RollD20() => GetNumber(20);
    public static int Roll(int number) => GetNumber(number);
}