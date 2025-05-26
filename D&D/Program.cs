public class Program
{
    public static Monster CreateElfEnemy()
    {
        List<Drop> testDrops = [new Drop(new Weapon("Spada", 30, ItemSlot.Weapon1, DiceValues.D12), 100)];
        Monster enemyElf = new("Elfo", new Elf(), new Barbarian(), testDrops);
        enemyElf.AddToInventory(new MagicWeapon("Spada Magica", 50, ItemSlot.Weapon2, DiceValues.D10, 5));
        enemyElf.Equip(new MagicWeapon("Spada Magica", 50, ItemSlot.Weapon2, DiceValues.D10, 5));
        return enemyElf;
    }
    public static Monster CreateOrcEnemy()
    {
        List<Drop> testDrops = [new Drop(new Weapon("Ascia", 35, ItemSlot.Weapon2, DiceValues.D12), 100)];
        Monster enemyOrc = new("Orco", new Gnome(), new Paladin(), testDrops);
        enemyOrc.AddToInventory(new Armor("Armatura di cuoio", 20, 3, ItemSlot.Chest, ArmorType.Light));
        enemyOrc.Equip(new Armor("Armatura di cuoio", 20, 3, ItemSlot.Chest, ArmorType.Light));
        return enemyOrc;
    }

    public static Monster CreateEnemy()
    {
        int roll = Dice.Roll(100);
        if (roll <= 50)
        {
            return CreateElfEnemy();
        }
        else
        {
            return CreateOrcEnemy();
        }
    }

    public static void EnemyAttack(Monster attacker, Adventurer target)
    {
        int roll = Dice.Roll(100);
        if (roll <= 50)
        {
            attacker.MeleeAttack(target);
        }
        else
        {
            attacker.RangedAttack(target);
        }
    }

    public static Race RaceSelection()
    {
        Console.WriteLine("Scegli la razza: ");
        Console.WriteLine("1. Umano; 2. Nano; 3. Elfo; 4. Gnomo.");
        int raceChoice = Convert.ToInt32(Console.ReadLine());
        switch (raceChoice)
        {
            case 1:
                return new Human();
            case 2:
                return new Dwarf();
            case 3:
                return new Elf();
            case 4:
                return new Gnome();
            default:
                Console.WriteLine("Scelta non valida. Riprova.");
                return RaceSelection();
        }
    }

    public static AdventurerClass ClassSelection()
    {
        Console.WriteLine("Scegli la classe: ");
        Console.WriteLine("1. Barbaro; 2. Mago; 3. Paladino; 4. Ladro.");
        int classChoice = Convert.ToInt32(Console.ReadLine());
        switch (classChoice)
        {
            case 1:
                return new Barbarian();
            case 2:
                return new Mage();
            case 3:
                return new Paladin();
            case 4:
                return new Rogue();
            default:
                Console.WriteLine("Scelta non valida. Riprova.");
                return ClassSelection();
        }
    }

    public static Adventurer CreateCharacter()
    {
        Console.Write("Inserisci il nome del personaggio: ");
        string? name = Console.ReadLine();
        Race race = RaceSelection();
        AdventurerClass adventurerClass = ClassSelection();
        Adventurer character = new(name, race, adventurerClass);
        return character;
    }

    public static void CreateDefaultEquipment(Adventurer character)
    {
        Weapon startingWeapon = new Weapon("Spada", 30, ItemSlot.Weapon1, DiceValues.D12);
        Armor startingArmor = new Armor("Armatura di cuoio", 20, 10, ItemSlot.Chest, ArmorType.Light);
        character.AddToInventory(startingWeapon);
        character.AddToInventory(startingArmor);
        character.Equip(startingWeapon);
        character.Equip(startingArmor);
    }

    public static void Main(string[] args)
    {
        Adventurer character = CreateCharacter();
        Console.WriteLine($"Inizia la tua avventura!");
        Console.WriteLine(character.ToString());
        while (character.IsAlive)
        {
            int roll = Dice.Roll(100);
            if (roll <= 60)
            {
                Console.WriteLine("Stai esplorando...");
                Console.ReadLine();
            }
            else if (roll <= 80)
            {
                Monster enemy = CreateEnemy();
                Console.WriteLine($"Hai incontrato un {enemy.Name} nemico!");
                while (enemy.IsAlive && character.IsAlive)
                {
                    Console.WriteLine("Che cosa vuoi fare?");
                    Console.WriteLine("1. Attacco ravvicinato; 2. Attacco a distanza.");
                    int actionChoice = Convert.ToInt32(Console.ReadLine());
                    switch (actionChoice)
                    {
                        case 1:
                            character.MeleeAttack(enemy);
                            break;
                        case 2:
                            character.RangedAttack(enemy);
                            break;
                        default:
                            Console.WriteLine("Azione non valida.");
                            continue;
                    }
                    Console.WriteLine("Il nemico attacca!");
                    EnemyAttack(enemy, character);
                }
            }
        }
    }
}