using UnityEngine;
using DatabaseManager;
using System.Collections.Generic;
using TMPro;

public class Аuthentication : MonoBehaviour
{
    [SerializeField] private TMP_InputField _input1;
    [SerializeField] private TMP_InputField _input2;

    public void LogIn()
    {
        List<string> resultArray1 = new List<string>(SqlQuery.ExecuteQuerySelect("SELECT login FROM Users").Split(';'));

        foreach (var result in resultArray1)
        {
            if (result == _input1.text)
            {
                List<string> resultArray2 = new List<string>(SqlQuery.ExecuteQuerySelect("SELECT password FROM Users").Split(';'));

                foreach (var resultic in resultArray2)
                {
                    if (resultic == _input2.text)
                    {
                        string name = _input1.text;
                        name = name.Replace(";", "");
                        string role = SqlQuery.ExecuteQuerySelect($"SELECT roleId FROM Users WHERE login = '{name}'");
                        role = role.Replace(";", "");
                        Debug.Log(role);
                        Debug.Log(SqlQuery.ExecuteQuerySelect($"SELECT roleName FROM Roles WHERE roleId = {System.Convert.ToInt32(role)}"));
                    }
                }
            }
        }
    }
}

