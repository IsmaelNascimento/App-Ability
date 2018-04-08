using System.Collections.Generic;
using UnityEngine;

public class GenerateSchools : MonoBehaviour
{
    private static string EmailDiretor = "anesioneto@hotmail.com";
    private static string[] Ceps = { "04552050", "20000000", "20010020", "20010130", "20060080" };

    public static List<School> GetSchools(int countSchools)
    {
        var schools = new List<School>();

        for (int i = 0; i < countSchools; i++)
        {
            schools.Add(new School()
            {
                EmailDiretor = EmailDiretor,
                Cep = Ceps[Random.Range(0, Ceps.Length)]
            });
        }

        return schools;
    }
}