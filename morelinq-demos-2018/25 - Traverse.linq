<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// TraverseDepthFirst, TraverseBreadthFirst
void Main()
{
	var queen = new Person("Queen Elizabeth", 
			new Person("Prince Charles", 
				new Person("Prince William",
					new Person("Prince George"), 
					new Person("Princess Charlotte"),
					new Person("Prince Louis")),
				new Person("Prince Harry")), 
			new Person("Princess Anne", 
				new Person("Peter",
					new Person("Savanah"),
					new Person("Isla")), 
				new Person("Zara",
					new Person("Mia"),
					new Person("Lena"))), 
			new Person("Prince Andrew", 
				new Person("Princess Beatrice"),
				new Person("Princess Eugenie")),
			new Person("Prince Edward", 
				new Person("Lady Louise"),
				new Person("Viscount Severn")
				)); // https://www.britroyals.com/images/royal_family.jpg
	
	MoreEnumerable.TraverseBreadthFirst(queen, p => p.Children).Select(p => p.Name).Dump("BreadthFirst");
	MoreEnumerable.TraverseDepthFirst(queen, p => p.Children).Select(p => p.Name).Dump("DepthFirst");
}

class Person
{
	public Person(string name, params Person[] children) {
		Name = name;
		Children = children;
	}	
	public string Name { get; set;}
	public IEnumerable<Person> Children { get; set;}
}