using System.Diagnostics;
using paternProxy;

using UserContext db = new UserContext();

if(!db.Users.Any())
{
    List<UserInfo> data = new List<UserInfo>()
    {
        new UserInfo(1, "Name: Анна Иванова, Age: 28"),
        new UserInfo(2, "Name: Иван Петров, Age: 35"),
        new UserInfo(3, "Name: Елена Смирнова, Age: 42"),
        new UserInfo(4, "Name: Александр Козлов, Age: 25"),
        new UserInfo(5, "Name: Татьяна Новикова, Age: 31"),
        new UserInfo(6, "Name: Дмитрий Морозов, Age: 40"),
        new UserInfo(7, "Name: Ольга Павлова, Age: 22"),
        new UserInfo(8, "Name: Сергей Соколов, Age: 38"),
        new UserInfo(9, "Name: Мария Федорова, Age: 45"),
        new UserInfo(10, "Name: Андрей Кузнецов, Age: 29"),
    }; 
    db.Users.AddRange(data);
    db.SaveChanges();
}
var user = new ProxyUser(10,db);

Console.WriteLine(user.GetInfo());

foreach (var dbUser in db.Users)
{
    if (dbUser.Id == 10)
    {
        dbUser.Info = "Name: Кузнец Андреев, Age:3";
        db.SaveChanges();
        break;
    }
}

Console.WriteLine(user.GetInfo());