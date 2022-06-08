<Query Kind="FSharpProgram" />

let input = File.ReadAllLines(
                Path.GetDirectoryName(Util.CurrentQueryPath) +
                "\\day5.txt")

let (=~) input pattern = Regex.IsMatch(input, pattern)
   
let hasThreeVowels s = s =~ @"[aeiou].*[aeiou].*[aeiou]"
let hasDoubleLetter s = s =~ @"(\w)\1+"
let containsNaughtyString s = s =~ @"ab|cd|pq|xy"

let isNice s = (hasThreeVowels s) && (hasDoubleLetter s) && (not (containsNaughtyString s))

input
    |> Seq.filter isNice
    |> Seq.length
    |> sprintf "a: %d"
    |> Dump


//"aabcdebccfaa"
let containsNonOverlappingPair s = s =~ @"(\w{2}).*\1+"
let containsDuplicateSeparatedByOne s = s =~ @"(\w).\1"

let isNiceB s =
    (containsNonOverlappingPair s) && (containsDuplicateSeparatedByOne s)
    
// test cases
isNiceB "qjhvhtzxzqqjkmpb" 
    |> Dump
    
isNiceB "xxyxx"
    |> Dump
    
isNiceB "uurcxstgmygtbstg" 
    |> Dump
    
isNiceB "ieodomkazucvgmuy" 
    |> Dump

input
    |> Seq.filter isNiceB
    |> Seq.length
    |> sprintf "b: %d"
    |> Dump
// 51
   
// regexes credit to mermop: https://github.com/mermop/advent-of-code-ruby/blob/master/05-01-strings.rb