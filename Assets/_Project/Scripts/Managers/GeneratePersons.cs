using System.Collections.Generic;
using UnityEngine;

public class GeneratePersons
{
    private static string[] names = { "Miguel", "Davi", "Arthur", "Pedro", "Gabriel" };
    private static string[] lastNames = { "Bernardo", "Lucas", "Matheus", "Rafael", "Heitor" };
    private static string[] emails = { "ismael.ismaio@gmail.com" };

    public static List<Person> GetPersons(int countPersons)
    {
        var persons = new List<Person>();

        for (int i = 0; i < countPersons; i++)
        {
            persons.Add(new Person()
            {
                Name = string.Format("{0} {1}", names[Random.Range(0, names.Length)], lastNames[Random.Range(0, lastNames.Length)]),
                AverageNote = Random.Range(0, 10),
                SchoolFrequency = Random.Range(50, 100),
                EmailEscola = emails[0]
            });
        }

        return persons;
    }
}