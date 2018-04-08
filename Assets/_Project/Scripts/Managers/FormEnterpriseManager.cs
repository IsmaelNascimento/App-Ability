using UnityEngine;
using UnityEngine.UI;

public class FormEnterpriseManager : MonoBehaviour
{
    public static FormEnterpriseManager Instance;

    [SerializeField] private InputField m_Email;
    [SerializeField] private InputField m_NameEnterprise;
    [SerializeField] private InputField m_Cnpj;
    [SerializeField] private InputField m_Phone;
    [SerializeField] private InputField m_Cep;
    [SerializeField] private InputField m_Address;
    [SerializeField] private Dropdown m_NameOpportunity;
    [SerializeField] private InputField m_NameRecruiter;
    [SerializeField] private Dropdown m_CountOpportunitys;
    [SerializeField] private InputField m_DescriptionOpportunity;

    private void Awake()
    {
        Instance = this;
    }

    #region Getters

    public string GetEmail()
    {
        return m_Email.text;
    }

    public string GetNameEnterprise()
    {
        return m_NameEnterprise.text;
    }

    public string GetCnpj()
    {
        return m_Cnpj.text;
    }

    public string GetPhone()
    {
        return m_Phone.text;
    }

    public string GetCep()
    {
        return m_Cep.text;
    }

    public string GetAddress()
    {
        return m_Address.text;
    }

    public string GetNameOpportunity()
    {
        return m_NameOpportunity.options[m_NameOpportunity.value].text;
    }

    public string GetNameRecruiter()
    {
        return m_NameRecruiter.text;
    }

    public string GetCountOpportunitys()
    {
        return m_CountOpportunitys.options[m_CountOpportunitys.value].text;
    }

    public string GetDescriptionOpportunity()
    {
        return m_DescriptionOpportunity.text;
    }

    #endregion

    #region Setters

    public void SetEmail(string value)
    {
        m_Email.text = value;
    }

    public void SetNameEnterprise(string value)
    {
        m_NameEnterprise.text = value;
    }

    public void SetCnpj(string value)
    {
        m_Cnpj.text = value;
    }

    public void SetPhone(string value)
    {
        m_Phone.text = value;
    }

    public void SetCep(string value)
    {
        m_Cep.text = value;
    }

    public void SetAddress(string value)
    {
        m_Address.text = value;
    }

    public void SetNameOpportunity(string value)
    {
        m_NameOpportunity.options[m_NameOpportunity.value].text = value;
    }

    public void SetNameRecruiter(string value)
    {
        m_NameRecruiter.text = value;
    }

    public void SetCountOpportunitys(string value)
    {
        m_CountOpportunitys.options[m_CountOpportunitys.value].text = value;
    }

    public void SetDescriptionOpportunity(string value)
    {
        m_DescriptionOpportunity.text = value;
    }

    #endregion

}