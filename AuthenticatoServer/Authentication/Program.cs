// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

AuthenticatoServer.DBConnection db = new();

db.AddDB("Pippazzo");
//Console.WriteLine($"{db.SQLConn.Database}");
//Authentication.Account newAccount = new("Pino");


if (db.SQLConn != null && db.Stop())
    Console.WriteLine($"The {db.SQLConn.Database} DB Connection Closed");
