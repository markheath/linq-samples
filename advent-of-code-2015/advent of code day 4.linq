<Query Kind="Statements" />

var secretKey = "iwrupvqb"; //"pqrstuv"; //"abcdef";
var md5 = System.Security.Cryptography.MD5.Create();
var q = from n in Enumerable.Range(1, 10000000)
    let inputString = $"{secretKey}{n}"
    let inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString)
    let hashBytes = md5.ComputeHash(inputBytes)
    let hashString = BitConverter.ToString(hashBytes).Replace("-","")
where hashString.StartsWith("00000") // a: five zeroes, b: six zeroes
select new { n, hashString };
q.FirstOrDefault().Dump();

/*Enumerable.Range(1, 1000000)
    .Select(n => $"{secretKey}{n}")
    .Select(s => System.Text.Encoding.ASCII.GetBytes(s))
    .Select(b => md5.ComputeHash(b))
    .Select(h => BitConverter.ToString(h).Replace("-",""))
    .Where(h => h.StartsWith("00000"))
    .Dump();*/