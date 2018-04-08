using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private List<Person> persons = new List<Person>();
    private List<School> schools = new List<School>();

    private List<Person> personsMatch = new List<Person>();

    [Header("Controllers")]
    [SerializeField] private int m_CountPersons = 5;
    [SerializeField] private int m_CountSchools = 5;
    [SerializeField] private int m_AverageNotePerson = 7;
    [SerializeField] private int m_AverageFrequencyPerson = 60;

    #region Methods MonoBehaviour

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InsertPersons();
        InsertSchools();
    }

    #endregion

    #region Insert Datas

    private void InsertPersons()
    {
        foreach (var person in GeneratePersons.GetPersons(m_CountPersons))
            persons.Add(person);
    }

    private void InsertSchools()
    {
        foreach (var school in GenerateSchools.GetSchools(m_CountSchools))
            schools.Add(school);
    }

    #endregion

    #region Methods General

    private int MatchOpportunityAndPersons()
    {
        var countOpportunitys = 0;
        var personsMatchAux = persons.Where(x => x.AverageNote >= m_AverageNotePerson || x.SchoolFrequency >= m_AverageFrequencyPerson).ToList();

        if (personsMatchAux.Count >= int.Parse(FormEnterpriseManager.Instance.GetCountOpportunitys()))
            countOpportunitys = int.Parse(FormEnterpriseManager.Instance.GetCountOpportunitys());
        else
            countOpportunitys = personsMatchAux.Count;

        for (int i = 0; i < countOpportunitys; i++)
            personsMatch.Add(personsMatchAux[i]);

        return countOpportunitys;
    }

    private void SendEmailSchools()
    {
        StartCoroutine(SendEmailSchools_Coroutine());
    }

    #endregion

    #region UI Managers

    public void OnButtonMatchClicked()
    {
        var countPersons = MatchOpportunityAndPersons(); 
        var messageMatch = string.Format("{0} talentos encontrado", countPersons);

        // Send Email for Enterprise 
        var subjectEmail = string.Format("Solicitado seus talentos em {0}", DateTime.Now);
        var bodyEmail = string.Format("Obrigado por usar nossa plataforma !");
        SendEmailManager.Instance.SendEmail(FormEnterpriseManager.Instance.GetEmail(), subjectEmail, bodyEmail, (x, y) => print("Email for Recruiter, send with Success"), callbackError: () => print("Error Send email for Recruiter"));
        SendEmailSchools();

        UIManager.Instance.SetTextResulMatch(messageMatch);
    }
    
    #endregion

    private IEnumerator SendEmailSchools_Coroutine()
    {
        var send = false;

        foreach (var person in personsMatch)
        {
            var subjectEmail = string.Format("{0} foi escolhido...", person.Name);
            var bodyEmail = string.Format("Parabéns Diretor.\n" +
                "O aluno {0} foi selecionado para a vaga {1} na empresa {2}\n \n" +
                "Descrição da vaga: \n{3} \n \n" +
                "COMO APLICAR:\n" +
                "Os alunos devem entrar em contato pelo telefone {4} procurando pelo contato {5}.\n \n" +
                "É importante identificar a vaga {6}\n \n" +
                "Entre em nosso site, e saiba mais sobre a plataforma\n{7}", person.Name, FormEnterpriseManager.Instance.GetNameOpportunity(),
                                                                    FormEnterpriseManager.Instance.GetNameEnterprise(),
                                                                    FormEnterpriseManager.Instance.GetDescriptionOpportunity(),
                                                                    FormEnterpriseManager.Instance.GetPhone(),
                                                                    FormEnterpriseManager.Instance.GetNameRecruiter(),
                                                                    FormEnterpriseManager.Instance.GetNameOpportunity(),
                                                                    "www.google.com");

            SendEmailManager.Instance.SendEmail(person.EmailEscola, subjectEmail, bodyEmail, (x, y) => send = true, callbackError: () => print("Error Send email for Recruiter"));

            yield return new WaitUntil(() => send);
            print("Email for Diretor, send with Success");
            send = false;
        }
    }
}