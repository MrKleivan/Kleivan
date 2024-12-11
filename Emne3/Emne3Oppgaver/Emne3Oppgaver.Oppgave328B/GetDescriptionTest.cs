﻿using NUnit.Framework;
namespace Emne3Oppgaver.Oppgave328B;

public class GetDescriptionTest
{
    [Test]
    public void TestAllFields()
    {
        var p = new Person
        {
            Id = 17,
            FirstName = "Ola",
            LastName = "Nordmann",
            BirthYear = 2000,
            DeathYear = 3000,
            Father = new Person() { Id = 23, FirstName = "Per" },
            Mother = new Person() { Id = 29, FirstName = "Lise" }
        };

        var actualDescription = p.GetDescription();
        var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

        Assert.That(actualDescription, Is.EqualTo(expectedDescription));
    }
    
    [Test]
    public void TestNoFields()
    {
        var p = new Person
        {
            Id = 1,
        };

        var actualDescription = p.GetDescription();
        var expectedDescription = "(Id=1)";

        Assert.That(expectedDescription, Is.EqualTo(actualDescription));
    }
    
    [Test]
    public void Test()
    {
        var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
        var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
        var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
        var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
        sverreMagnus.Father = haakon;
        ingridAlexandra.Father = haakon;
        haakon.Father = harald;

        var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
        var actualResponse = app.HandleCommand("vis 3");
        var expectedResponse = "Haakon Magnus (Id=3) Født: 1973 Far: Harald (Id=6)\n"
                               + "  Barn:\n"
                               + "    Sverre Magnus (Id=1) Født: 2005\n"
                               + "    Ingrid Alexandra (Id=2) Født: 2004\n";
        Assert.That(actualResponse, Is.EqualTo(expectedResponse));
    }
}