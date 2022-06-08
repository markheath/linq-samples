<Query Kind="Program" />

void Main()
{
	/*var testBoss = new PlayerStatus(12,7,2,0);
	var testPlayer = new PlayerStatus(8, 5, 5, 0);
	Battle(testPlayer, testBoss).Dump();*/

	/*var testPlayer = new PlayerStatus(100, 13, 3, 0);
	var testBoss = new PlayerStatus(103, 9, 2, 0);
	Battle(testPlayer, testBoss).Dump();*/

	//GetPlayerOptions(100).Dump();
	//var boss = new PlayerStatus(103, 9, 2, 0);
	var options = GetPlayerOptions(100).ToList();
		options
		.Where(x => Battle(x, new PlayerStatus(103, 9, 2, 0)))
		.OrderBy(x => x.GoldSpent)
		.Take(1)
		.Dump("a");

	GetPlayerOptions(100).ToList()
	.Where(x => !Battle(x, new PlayerStatus(103, 9, 2, 0)))
	.OrderByDescending(x => x.GoldSpent)
	.Take(1)
	.Dump("b");
}


class ShopItem
{
	public ShopItem(string name, int cost, int damage, int armor)
	{
		Name = name;
		Cost = cost;
		Damage = damage;
		Armor = armor;
	}
	public string Name { get; }
	public int Cost { get; }
	public int Damage { get; }
	public int Armor { get; }
}

List<ShopItem> weapons = new List<ShopItem>()
{
	new ShopItem("Dagger",8,4,0),
	new ShopItem("Shortsword",10,5,0),
	new ShopItem("Warhammer",25,6,0),
	new ShopItem("Longsword",40,7,0),
	new ShopItem("Greataxe",74,8,0),
};

List<ShopItem> armory = new List<ShopItem>()
{
	new ShopItem("Leather",13,0,1),
	new ShopItem("Chainmail",31,0,2),
	new ShopItem("Splintmail",53,0,3),
	new ShopItem("Bandedmail",75,0,4),
	new ShopItem("Platemail",102,0,5),
};

List<ShopItem> rings = new List<ShopItem>()
{
	new ShopItem("Damage +1", 25,1,0),
	new ShopItem("Damage +2", 50,2,0),
	new ShopItem("Damage +3", 100,3,0),
	new ShopItem("Defense +1", 20,0,1),
	new ShopItem("Defense +2", 40,0,2),
	new ShopItem("Defense +3", 80,0,3)
};

IEnumerable<PlayerStatus> GetPlayerOptions(int hitPoints)
{
	var startStatus = new PlayerStatus(hitPoints, 0, 0, 0);
	foreach (var weapon in weapons)
	{
		var ps = startStatus.PowerupWith(weapon);
		yield return ps;
		foreach (var powerup in AddRings(ps))
			yield return powerup;
		foreach (var armor in armory)
		{
			var ps2 = ps.PowerupWith(armor);
			yield return ps2;
			foreach (var powerup in AddRings(ps2))
				yield return powerup;
		}
	}
}

IEnumerable<PlayerStatus> AddRings(PlayerStatus status)
{
	foreach (var ring1 in rings)
	{
		var with1Ring = status.PowerupWith(ring1);
		yield return with1Ring;
		foreach (var ring2 in rings.Where(r => r != ring1))
		{
			yield return with1Ring.PowerupWith(ring2);
		}
	}
}

bool Battle(PlayerStatus player, PlayerStatus boss)
{
	while (player.HitPoints > 0 && boss.HitPoints > 0)
	{
		boss.HitPoints -= (player.Damage - boss.Armor);
		//Console.WriteLine("Boss: {0}",boss.HitPoints);
		if (boss.HitPoints <= 0) break;
		player.HitPoints -= (boss.Damage - player.Armor);
		//Console.WriteLine("Player: {0}", player.HitPoints);
	}
	return player.HitPoints > 0;
}

class PlayerStatus
{
	public PlayerStatus(int hp, int d, int a, int g)
	{
		HitPoints = hp;
		Damage = d;
		Armor = a;
		GoldSpent = g;
		Setup = "";
	}
	public int HitPoints { get; set; }
	public int Damage { get; }
	public int Armor { get;  }
	public int GoldSpent { get; }
	public string Setup { get; private set; }

	public PlayerStatus PowerupWith(ShopItem item)
	{
		return new PlayerStatus(HitPoints, Damage + item.Damage, Armor + item.Armor, GoldSpent + item.Cost) { Setup = Setup + "," + item.Name };
	}
}