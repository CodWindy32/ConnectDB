using DatabaseManager;
using System;
using TMPro;
using UnityEngine;

namespace PersonalList
{
    public class PersonalServiceAdding : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdownRole;

        [SerializeField] private TMP_InputField inputName;
        [SerializeField] private TMP_InputField inputLogin;
        [SerializeField] private TMP_InputField inputPassword;
        [SerializeField] private TMP_InputField inputAge;

        public void AddPersonal()
        {
            string role = SqlQuery.ExecuteQuerySelect($"SELECT roleId FROM Roles WHERE roleName = '{_dropdownRole.options[_dropdownRole.value].text}'", false);
            SqlQuery.ExecuteQueryEditing($"INSERT INTO Users (fullName, age, login, password, roleId) VALUES('{inputName.text}'," +
                $" '{Convert.ToInt32(inputAge.text)}','{inputLogin.text}','{inputPassword.text}','{Convert.ToInt32(role)}')");
        }
    }
}

