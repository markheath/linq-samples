<Query Kind="FSharpProgram" />

let factors number = seq {
    for divisor in 1.. (float >> sqrt >> int) number do
        let a,b = number%divisor, number/divisor
        if a = 0 then
            yield divisor
            if not (divisor = b) then
                yield b }

//factors 60 |> Dump
                
let presentsForHouseA house = 
    factors house
    |> Seq.sum 
    |> ((*) 10)

let presentsForHouseB house = 
    factors house
    |> Seq.filter (fun factor -> house/factor <= 50)
    |> Seq.sum 
    |> ((*) 11)

let search target func testSeq =
    testSeq
    |> Seq.map (fun house -> (house, (func house)))
    |> Seq.find (fun (h,p) -> p > target) |> fst

  
//[1..10] |> Seq.map presentsForHouseB |> Dump

let target = 36000000

let testNums rstart factor = 
    seq { for n in rstart..target do if n % factor = 0 then yield n }


testNums 700000 (2*3*5*7*11)
|> search target presentsForHouseA 
|> printfn "a: %d" //831600

testNums 700000 (2*2*2*3*3)
|> search target presentsForHouseB 
|> printfn "b: %d" // 884520

// original 18 minutes 30!
// with sqrt factors: 1 second