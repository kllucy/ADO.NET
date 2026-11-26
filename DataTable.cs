DataTable (DataRow DataColumn)
DataSet (
DataAdapter 

1) Подключились 
2) Получили данные
3) Отключились
4) Локально работаете
5) Подключились 
6) Загрузили
7) Отключились

using System;
using System.Data;

var table = new DataTable();
var colId = new DataColumn("id", typeof(int))
{
    AutoIncrement = true,
    AutoIncrementSeed=1,
    AutoIncrementStep = 1
};
var colTitle = new DataColumn("title", typeof(string))
{
    Unique = true,
    AllowDBNull = false
};
table.Columns.Add(colId);
table.Columns.Add(colTitle);
table.Columns.Add("name", typeof(string));
table.Columns.Add("author", typeof(string));
table.Columns.Add("release", typeof(DateTime));
table.Columns.Add("description", typeof(string));

table.Rows.Add(1, "Война и мир", "Лев Толстой", new DateTime(1869, 1, 1), "Роман-эпопея");
table.Rows.Add(2, "Преступление и наказание", "Федор Достоевский", new DateTime(1866, 1, 1), "Психологический роман");

foreach (DataRow row in table.Rows)
{ 
    DateTime releaseDate = (DateTime)row["release"];
    Console.WriteLine($"{row["id"]} - {row["name"]} | Автор: {row["author"]} |Дата: {releaseDate:realise} | {row["description"]}");
}

