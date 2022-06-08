<Query Kind="FSharpProgram" />

type ShopItem = { Name : string; Cost: int; Damage: int; Armor: int }
type Player = {HitPoints : int; Damage: int; Armor: int; GoldSpent: int; Inventory: string list }
let powerupWith (player:Player) (item:ShopItem) = 
    { player with Damage = player.Damage + item.Damage; 
                    Armor = player.Armor + item.Armor;
                    GoldSpent = player.GoldSpent + item.Cost;
                    Inventory = (item.Name)::(player.Inventory)}
let hitBy (player:Player) (opponent:Player) = { player with HitPoints = player.HitPoints - opponent.Damage + player.Armor }

let weapons = [
    {Name="Dagger";Cost=8;Damage=4;Armor=0};
    {Name="Shortsword";Cost=10;Damage=5;Armor=0};
    {Name="Warhammer";Cost=25;Damage=6;Armor=0};
    {Name="Longsword";Cost=40;Damage=7;Armor=0};
    {Name="Greataxe";Cost=74;Damage=8;Armor=0};
    ]
let armory = [
    {Name="Leather";Cost=13;Damage=0;Armor=1};
    {Name="Chainmail";Cost=31;Damage=0;Armor=2};
    {Name="Splintmail";Cost=53;Damage=0;Armor=3};
    {Name="Bandedmail";Cost=75;Damage=0;Armor=4};
    {Name="Platemail";Cost=102;Damage=0;Armor=5};
    ]
let rings = [
    {Name="Damage +1";  Cost=25;  Damage=1; Armor=0};
    {Name="Damage +2";  Cost=50;  Damage=2; Armor=0};
    {Name="Damage +3";  Cost=100; Damage=3; Armor=0};
    {Name="Defense +1"; Cost=20;  Damage=0; Armor=1};
    {Name="Defense +2"; Cost=40;  Damage=0; Armor=2};
    {Name="Defense +3"; Cost=80;  Damage=0; Armor=3}
]

let addRings player = seq {
    for ring1 in rings do
        let with1Ring = powerupWith player ring1
        yield with1Ring
        for ring2 in rings |> Seq.except [ring1] do
            yield powerupWith with1Ring ring2
    }
    
let getOptions hitPoints = seq {
    let startStatus = { HitPoints = hitPoints; Damage =0; Armor = 0; GoldSpent = 0; Inventory = []}
    for weapon in weapons do
        let ps = powerupWith startStatus weapon
        yield ps
        yield! addRings ps
        for armor in armory do
            let ps2 = powerupWith ps armor
            yield ps2;
            yield! addRings ps2
}

//getOptions 100 |> Dump

let rec battle boss player =
    let b2 = hitBy boss player
    //printfn "Boss %d" b2.HitPoints
    if b2.HitPoints > 0 then
        let p2 = hitBy player boss
        //printfn "Player %d" p2.HitPoints
        if p2.HitPoints > 0 then
            battle b2 p2
        else false
    else true

let boss = { HitPoints = 103; Damage= 9; Armor = 2; GoldSpent = 0; Inventory = [] }
let testPlayer = { HitPoints = 100; Damage= 9; Armor = 2; GoldSpent = 0; Inventory = [] }

//battle boss testPlayer |> Dump

let getGold p = p.GoldSpent
getOptions 100 |> Seq.filter (battle boss) |> Seq.minBy getGold |> getGold |> printfn "a: %d"
getOptions 100 |> Seq.filter ((battle boss) >> not) |> Seq.maxBy getGold |> getGold |> printfn "b: %d"
