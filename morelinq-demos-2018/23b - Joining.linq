<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// 23 RightJoin, LeftJoin, FullJoin, FullGroupJoin, Unions

class Author
{
	public int Id { get; set; }
	public string Name { get; set; }
}

class Book
{
	public int AuthorId { get; set; }
	public string Name { get; set; }
}

void Main()
{
	var authors = new[] { new Author { Id = 1, Name = "Elton Stoneman" },
					  new Author { Id = 2, Name = "Andrew Lock" },
					  new Author { Id = 3, Name = "Mark Heath" },
					};
	var books = new[] { new Book { AuthorId = 1, Name = "Docker on Windows" },
					new Book { AuthorId = 2, Name = "ASP.NET Core in Action" },
					new Book { AuthorId = 1, Name = "Docker Succinctly" },
					new Book { AuthorId = 9, Name = "Functional Programming in C#" } }; // Enrico Buonanno

	books.RightJoin(authors, 
		b => b.AuthorId, 
		a => a.Id, 
		a => $"{a.Name} has no books", 
		(b, a) => $"{b.Name} by {a.Name}")
		.Dump("RightJoin");
	
	books.LeftJoin(authors, 
		b => b.AuthorId, 
		a => a.Id, 
		b => $"{b.Name} by Unknown Author", 
		(b, a) => $"{b.Name} by {a.Name}")
		.Dump("LeftJoin");
	
	books.FullJoin(authors, 
		b => b.AuthorId, 
		a => a.Id, 
		b => $"{b.Name} by Unknown Author", 
		a => $"{a.Name} has no books", 
		(b, a) => $"{b.Name} by {a.Name}")
		.Dump("FullJoin");
	
	books.FullGroupJoin(authors, b => b.AuthorId, a => a.Id)
		.Dump("FullGroupJoin");


	var books2 = new[] { 
					new Book { AuthorId = 2, Name = "ASP.NET Core in Action" },
					
					new Book { AuthorId = 6, Name = "Get Programming with F#" } }; // Isaac Abraham
	books.Union(books2, new BookComparer()).Dump();
}

class BookComparer : IEqualityComparer<Book>
{
	public bool Equals(Book x, Book y)
	{
		return x.Name == y.Name && x.AuthorId == y.AuthorId;
	}

	public int GetHashCode(Book obj)
	{
		return obj.AuthorId.GetHashCode() ^ obj.Name.GetHashCode();
	}
}