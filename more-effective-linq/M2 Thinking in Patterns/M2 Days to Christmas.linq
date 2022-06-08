<Query Kind="Statements" />

var daysToChristmas = (new DateTime(DateTime.Today.Year, 12, 25) - DateTime.Today).TotalDays;
daysToChristmas.Dump();