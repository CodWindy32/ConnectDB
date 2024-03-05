using DatabaseManager;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ServiceManager
{
    public class TimestableUserManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dataText;
        [SerializeField] private TextMeshProUGUI _personalNameOne;
        [SerializeField] private TextMeshProUGUI _personalNameTwo;
        [SerializeField] private TextMeshProUGUI _personalRoleOne;
        [SerializeField] private TextMeshProUGUI _personalRoleTwo;

        [SerializeField] private GameObject _timetablesBtn;

        private DateTime _currentDate;
        public static string dateString;

        private void Start()
        {
            _currentDate = DateTime.Today;
        }

        public void OnTimestableNow(int minusDate)
        {
            _currentDate = _currentDate.AddDays(minusDate);
            dateString = _currentDate.ToString("yyyy-MM-dd");
            _dataText.text = $"Дата: {dateString}";
            string dayId = SqlQuery.ExecuteQuerySelect($"SELECT dayId FROM Days WHERE date = '{dateString}'", false);

            if (dayId != "")
            {
                TimestableNoEmpty(dayId);
            }
            else
            {
                TimestableIsNull();
            }
        }

        private void TimestableNoEmpty(string dayId)
        {
            List<string> resultArrayTimetable = new List<string>(SqlQuery.ExecuteQuerySelect($"SELECT userId FROM Timetables WHERE dayId = {Convert.ToInt32(dayId)}", true).Split(';'));

            _personalNameOne.text = $"Имя: {SqlQuery.ExecuteQuerySelect($"SELECT fullName FROM Users WHERE userId = {Convert.ToInt32(resultArrayTimetable[0])}", false)}";
            string role = SqlQuery.ExecuteQuerySelect($"SELECT roleId FROM Users WHERE fullName = '{SqlQuery.ExecuteQuerySelect($"SELECT fullName FROM Users WHERE userId = {Convert.ToInt32(resultArrayTimetable[0])}", false)}'", false);
            _personalRoleOne.text = $"Должность: {SqlQuery.ExecuteQuerySelect($"SELECT roleName FROM Roles WHERE roleId = {Convert.ToInt32(role)}", false)}";

            _personalNameTwo.text = $"Имя: {SqlQuery.ExecuteQuerySelect($"SELECT fullName FROM Users WHERE userId = {Convert.ToInt32(resultArrayTimetable[1])}", false)}";
            role = SqlQuery.ExecuteQuerySelect($"SELECT roleId FROM Users WHERE fullName = '{SqlQuery.ExecuteQuerySelect($"SELECT fullName FROM Users WHERE userId = {Convert.ToInt32(resultArrayTimetable[1])}", false)}'", false);
            _personalRoleTwo.text = $"Должность: {SqlQuery.ExecuteQuerySelect($"SELECT roleName FROM Roles WHERE roleId = {Convert.ToInt32(role)}", false)}";

            _timetablesBtn.SetActive(false);

            resultArrayTimetable.Clear();
        }

        private void TimestableIsNull()
        {
            _personalNameOne.text = "Не назначено.";
            _personalNameTwo.text = "Не назначено.";

            _timetablesBtn.SetActive(true);
        }
    }
}
