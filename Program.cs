using EasyCrudLocalPlayground.Entities;
using EasyCrudNET;
using System.Data.SqlClient;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var easyCrud = new EasyCrud();

easyCrud.SetSqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyCrud4CSharpDB;Trusted_Connection=True;MultipleActiveResultSets=true;");


List <PersonTest> peopleTest = new List<PersonTest>();

//Action<SqlDataReader> callback = (reader) =>
//{
//    while (reader.Read())
//    {
//        var person = new PersonTest();

//        person.Name = reader.GetValue(0).ToString();
//        person.Age = int.Parse(reader.GetValue(1).ToString());
//        person.IsActive = bool.Parse(reader.GetValue(2).ToString());

//        peopleTest.Add(person);
//    }
//};

peopleTest.AddRange(easyCrud.Execute(null, "").MapTo<PersonTest>();

easyCrud
    .Select("*")
    .From("Person_test")
    .Where()
    .GreaterThan("Age", "@age")
    .ExecuteAsync(new
    {
        Age = 20
    })
    .ConvertInto<PersonTest>();

Console.WriteLine(peopleTest);