

using System.Diagnostics.Metrics;
using Domain.Models;
using Infrastructure.Repositories;
using Npgsql.Replication;

var repo = new BookRepository();
var auth = new AuthorRepository();


// while (true)
// {
//     System.Console.WriteLine(@"1. show all books
// 2. Add book
// 3. Delete book by id
// 4. Update book
// 5. Show book by id
// 0. Exit");
//     var a = Console.ReadLine();
//     switch (a)
//     {
//         case "1":
//             var books = repo.GetBooks();
//             foreach (var it in books)
//             {
//                 Console.WriteLine(it.Id+" "+it.Title+" "+it.PublishYear+" "+it.TotalCopies);
//             }
//             break;
//         case "2":
//             System.Console.Write("Enter title: ");
//             string title = Console.ReadLine();
//             System.Console.Write("Enter publisheYear: ");
//             int publish = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter totalcopies: ");
//             int total = Convert.ToInt32(Console.ReadLine());
//             var books2 = new Book()
//             {
//                 Title = title,
//                 PublishYear = publish,
//                 TotalCopies = total
//             };
//             repo.AddBook(books2);
//             break;
//         case "3":
//             System.Console.Write("Enter id: ");
//             var id3 = Convert.ToInt32(Console.ReadLine());
//             repo.DeleteBook(id3);
//             break;
//         case "4":
//             Console.Write("Enter id: ");
//             int id4 = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter title: ");
//             string title4 = Console.ReadLine();
//             System.Console.Write("Enter publichedyear: ");
//             int published4 = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter totalcopies: ");
//             int total4 = Convert.ToInt32(Console.ReadLine());
//             var books4 = new Book()
//             {
//                 Id = id4,
//                 Title = title4,
//                 PublishYear = published4,
//                 TotalCopies = total4
//             };
//             repo.UpdateBook(books4);
//             break;
//         case "5":
//             System.Console.Write("Enter id: ");
//             var id5 = Convert.ToInt32(Console.ReadLine());
//             var books5 = repo.GetBook(id5);
//             System.Console.WriteLine(books5.Id+" "+books5.Title+" "+books5.PublishYear+" "+books5.TotalCopies     );
//             break;
//         case "0":
//         return;
//     }
// }


while (true)
{
    System.Console.WriteLine(@"1. Show all Author
2. Show by id
3. Add Author
4. Update Author
5. Delete Author
0. Exist");
    string a = Console.ReadLine();
    switch (a)
    {
        case "1":
            var author = auth.GetAuthors();
            foreach (var i in author)
            {
                Console.WriteLine(i.Id+" "+i.FullName+" "+i.Country+" "+i.BirthYear);
            }
            break;
        case "2":
            System.Console.Write("Enter id: ");
            int id2 = Convert.ToInt32(Console.ReadLine());
            var a2 = auth.GetAuthor(id2);
            System.Console.WriteLine(a2.Id+" "+a2.FullName+" "+a2.Country+" "+a2.BirthYear);
            break;
        case "3":
            System.Console.Write("Enter FullName: ");
            string name3 = Console.ReadLine();
            System.Console.Write("Enter Country: ");
            string country3 = Console.ReadLine();
            System.Console.Write("Enter BirthYear: ");
            int birth3 = Convert.ToInt32(Console.ReadLine());
            Author author3 = new()
            {
                FullName = name3,
                Country = country3,
                BirthYear = birth3
            };
            auth.AddAuthor(author3);
            break;
        case "4":
            System.Console.Write("Enter id: ");
            int id4 = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter FullName: ");
            string name4 = Console.ReadLine();
            System.Console.Write("Enter Country: ");
            string country4 = Console.ReadLine();
            System.Console.Write("Enter BirthYear: ");
            int birth4 = Convert.ToInt32(Console.ReadLine());
            Author author4 = new()
            {
                Id = id4,
                FullName = name4,
                Country = country4,
                BirthYear = birth4
            };
            auth.UpdateAuthor(author4);
            break;
        case "5":
            System.Console.Write("Enter id: ");
            int id5 = Convert.ToInt32(Console.ReadLine());
            auth.DeleteAuthor(id5);
            break;
        case "0":
            return;
    }
}