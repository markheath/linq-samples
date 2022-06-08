<Query Kind="Program" />

void Main()
{

	/*var testBoss = new PlayerStatus(12,7,2,0);
	var testPlayer = new PlayerStatus(8, 5, 5, 0);
	Battle(testPlayer, testBoss).Dump();*/

	var testPlayer = new PlayerStatus(100, 13, 3, 0);
	var testBoss = new PlayerStatus(103, 9, 2, 0);
	Battle(testPlayer, testBoss).Dump();

	var boss = new PlayerStatus(103, 9, 2, 0);
	var options = GetPlayerOptions(100); //.ToList();
		options
		.Where(x => Battle(x, boss))
		.OrderBy(x => x.GoldSpent)
		.First() //.GoldSpent
		.Dump("a"); // 121

	options
	.Where(x => !Battle(x, boss))
	.OrderByDescending(x => x.GoldSpent)
	.First().GoldSpent
	.Dump("b"); // 201



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

IEnumerable<PlayerStatus> GetPlayerOptions(int hitPoints)
{
	var startStatus = new PlayerStatus(hitPoints,0,0,0);
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

List<ShopItem> rings = new List<ShopItem>()
{
	new ShopItem("Damage +1", 25,1,0),
	new ShopItem("Damage +2", 50,2,0),
	new ShopItem("Damage +3", 100,3,0),
	new ShopItem("Defense +1", 20,0,1),
	new ShopItem("Defense +2", 40,0,2),
	new ShopItem("Defense +3", 80,0,3)
};

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


bool Battle(PlayerStatus player, PlayerStatus boss, bool debug = false)
{
	while (player.HitPoints > 0 && boss.HitPoints > 0)
	{
		boss = boss.HitBy(player);
		if (debug) Console.WriteLine("Boss: {0}",boss.HitPoints);
		if (boss.HitPoints <= 0) break;
		player = player.HitBy(boss);
		if (debug) Console.WriteLine("Player: {0}", player.HitPoints);
	}
	return player.HitPoints > 0;
}

class PlayerStatus
{
	public PlayerStatus(int hp, int d, int a, int g, string s = "")
	{
		HitPoints = hp;
		Damage = d;
		Armor = a;
		GoldSpent = g;
		Setup = s;
	}
	public int HitPoints { get; }
	public int Damage { get; }
	public int Armor { get;  }
	public int GoldSpent { get; }
	public string Setup { get; }

	public PlayerStatus PowerupWith(ShopItem item)
	{
		return new PlayerStatus(HitPoints, Damage + item.Damage, Armor + item.Armor, GoldSpent + item.Cost, Setup + "," + item.Name);
	}

	public PlayerStatus HitBy(PlayerStatus opponent)
	{
		return new PlayerStatus(HitPoints - opponent.Damage +Armor, Damage, Armor, GoldSpent, Setup);
	}
}