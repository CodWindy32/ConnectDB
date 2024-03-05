using DatabaseManager;
using TMPro;
using UnityEngine;
using System;

namespace ServiceManager
{
    public class TimestableManagerEdit : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputNameRoleOne;
        [SerializeField] private TMP_InputField _inputNameRoleTwo;

        public void TimetableEditor()
        {
            SqlQuery.ExecuteQueryEditing($"INSERT INTO Days (date) VALUES('{TimestableUserManager.dateString}')");

            string indexDay = SqlQuery.ExecuteQuerySelect($"SELECT dayId FROM Days WHERE date = '{TimestableUserManager.dateString}'", false);

            SqlQuery.ExecuteQueryEditing($"INSERT INTO Timetables (dayId, userId) VALUES('{Convert.ToInt32(indexDay)}','{Convert.ToInt32(UserTimeTable(_inputNameRoleOne.text))}')");
            SqlQuery.ExecuteQueryEditing($"INSERT INTO Timetables (dayId, userId) VALUES('{Convert.ToInt32(indexDay)}','{Convert.ToInt32(UserTimeTable(_inputNameRoleTwo.text))}')");

            GetComponent<TimestableUserManager>().OnTimestableNow(0);
        }

        private string UserTimeTable(string userName)
        {
            string idName = SqlQuery.ExecuteQuerySelect($"SELECT userId FROM Users WHERE fullName = '{userName}'", false);
            return idName;
        }
    }
}

