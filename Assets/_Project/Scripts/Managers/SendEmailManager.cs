using System;
using UnityEngine;
using System.ComponentModel;

public class SendEmailManager : MonoBehaviour
{
    public static SendEmailManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void SetupForSendEmail()
    {
        SimpleEmailSender.emailSettings.STMPClient = "smtp-mail.outlook.com";
        SimpleEmailSender.emailSettings.SMTPPort = 587;
        SimpleEmailSender.emailSettings.UserName = "ismaeln.business@outlook.com";
        SimpleEmailSender.emailSettings.UserPass = "123456fmA";
    }

    public void SendEmail(string emailReceive, string subjectEmail, string bodyEmail, Action<object, AsyncCompletedEventArgs> callbackSuccess, string pathAttachFile = "", Action callbackError = null)
    {
        SetupForSendEmail();

        try
        {
            SimpleEmailSender.Send(emailReceive, subjectEmail, bodyEmail, pathAttachFile, callbackSuccess);
        }
        catch(Exception e)
        {
            print("Error in SendEmail:: " + e);

            if (callbackError != null)
                callbackError();
        }
    }

    [ContextMenu("SendEmailTest")]
    public void SendEmailTest()
    {
        SendEmail("contato@ismaelnascimento.com", "Test with ContextMenu", "Send with ContextMenu", (x, y) => print("Send email with success"));
    }
}