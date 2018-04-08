using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Text txtResulMatch;

    private void Awake()
    {
        Instance = this;
    }

    public void SetTextResulMatch(string value)
    {
        txtResulMatch.text = value;
    }
}