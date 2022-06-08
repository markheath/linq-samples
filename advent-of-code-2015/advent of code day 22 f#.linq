<Query Kind="FSharpProgram" />

// solution by on LincolnA
// https://www.reddit.com/r/adventofcode/comments/3xspyl/day_22_solutions/cy7l1bq
type Spell = { Name : string; Cost : int; Damage : int; Heal : int; Armor : int; Mana : int; Duration : int }

let allSpells = 
    [ { Name = "Magic Missile"; Cost = 53;  Damage = 4; Heal = 0; Armor = 0; Mana = 0;   Duration = 1}
      { Name = "Drain";         Cost = 73;  Damage = 2; Heal = 2; Armor = 0; Mana = 0;   Duration = 1}
      { Name = "Shield";        Cost = 113; Damage = 0; Heal = 0; Armor = 7; Mana = 0;   Duration = 6}
      { Name = "Poison";        Cost = 173; Damage = 3; Heal = 0; Armor = 0; Mana = 0;   Duration = 6}
      { Name = "Recharge";      Cost = 229; Damage = 0; Heal = 0; Armor = 0; Mana = 101; Duration = 5} ]

let rec play part myTurn spent (hp, mana, spells) (bossHp, bossDamage) : seq<int option> =

    // part 2, check if I die before any effects play out
    if part = 2 && myTurn && hp = 1 then upcast [None] else

    // apply effects
    let mana = (spells |> List.sumBy (fun s -> s.Mana)) + mana
    let damage = spells |> List.sumBy (fun s -> s.Damage)
    let armor = spells |> List.sumBy (fun s -> s.Armor)

    // does the boss die from effects?
    let bossHp = bossHp - damage
    if bossHp <= 0 then upcast [Some(spent)] else

    // decrement duration of all effects, and groom expired ones
    let spells =
        spells
        |> List.map (fun s -> {s with Duration = s.Duration - 1})
        |> List.filter (fun s -> s.Duration > 0)

    if myTurn then
        // part 2, I lose 1 HP on my turn
        let hp = if part = 2 then hp - 1 else hp

        // what spells can I afford and don't already have running?
        let isBuyable s =
               (s.Cost <= mana) && 
               (spent + s.Cost < 1500) && // mark heath hack to speed up
               not (spells |> List.exists (fun s' -> s.Name = s'.Name))
        match allSpells |> List.filter isBuyable with
        | [] -> upcast [None]
        | buyableSpells ->
            // play out the rest of the game with each possible purchase
            seq { for s in buyableSpells do
                      let spent = spent + s.Cost
                      let mana = mana - s.Cost
                      let extraDamage, heal, spells = 
                          if s.Duration = 1 then s.Damage, s.Heal, spells
                          else 0, 0, s :: spells

                      let bossHp = bossHp - extraDamage
                      if bossHp <= 0 then
                          yield Some(spent)
                      else
                          yield! play part false spent (hp + heal, mana, spells) (bossHp, bossDamage) }

    // boss's turn
    else
        let damage = max (bossDamage - armor) 1
        let hp = hp - damage
        if hp <= 0 then upcast [None] else
        play part true spent (hp, mana, spells) (bossHp, bossDamage)

let lincolnBoss = (70,10)
let markBoss = (58,9)
play 1 true 0 (50, 500, []) markBoss |> Seq.choose id |> Seq.min |> printfn "Part 1 - min to win: %d"
play 2 true 0 (50, 500, []) markBoss |> Seq.choose id |> Seq.min |> printfn "Part 2 - min to win: %d"
// lincolnBoss: part 1 = 1771; part 2 = 1937; time taken = 38.6s
// markBoss: part 1 = ; part 2 = ; time taken = > 1h30 with no limit, with limit of 1500 solves in 34 second
