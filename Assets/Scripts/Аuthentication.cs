using UnityEngine;
using DatabaseManager;
using System.Collections.Generic;
using TMPro;
using DataUser;
using UserSystem;

public class Аuthentication : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputLogin;
    [SerializeField] private TMP_InputField _inputPassword;
    [SerializeField] private GameObject _warningLog;

    public void LogIn()
    {
        List<string> resultArrayLogin = new List<string>(SqlQuery.ExecuteQuerySelect("SELECT login FROM Users", true).Split(';'));

        foreach (var result in resultArrayLogin)
        {
            if (result == _inputLogin.text)
            {
                List<string> resultArrayPassword = new List<string>(SqlQuery.ExecuteQuerySelect("SELECT password FROM Users", true).Split(';'));

                foreach (var resultic in resultArrayPassword)
                {
                    if (resultic == _inputPassword.text)
                    {
                        _warningLog.SetActive(false);
                        UserDataApplication.UserDataApplicationSaved(_inputLogin.text);
                        UserSystenSettings.UserSystemScene();
                    }
                    else
                    {
                        _warningLog.SetActive(true);
                    }
                }
            }
            else
            {
                _warningLog.SetActive(true);
            }
        }
    }
}

