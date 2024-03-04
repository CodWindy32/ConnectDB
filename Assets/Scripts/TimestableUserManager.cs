using DatabaseManager;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimestableUserManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dataText;
    [SerializeField] private TextMeshProUGUI _personalNameOne;
    [SerializeField] private TextMeshProUGUI _personalNameTwo;
    [SerializeField] private TextMeshProUGUI _personalRoleOne;
    [SerializeField] private TextMeshProUGUI _personalRoleTwo;

    public void OnTimestableNow(int minusDate)
    {
        DateTime currentDate = DateTime.Today.AddDays(minusDate);
        string dateString = currentDate.ToString("yyyy-MM-dd");

        string dayId = SqlQuery.ExecuteQuerySelect($"SELECT dayId FROM Day WHERE day = '{dateString}'", false);
        List<string> resultArrayTimetable = new List<string>(SqlQuery.ExecuteQuerySelect($"SELECT userId FROM Timetables WHERE dayId = {Convert.ToInt32(dayId)}", true).Split(';'));
        //_personalNameOne.text =$"Имя: {SqlQuery.ExecuteQuerySelect($"SELECT fullName FROM Users WHERE userId = {Convert.ToInt32(resultArrayTimetable[0])}", false)}";
        //string role = SqlQuery.ExecuteQuerySelect($"SELECT roleId FROM Users WHERE fullName = '{_personalNameOne.text}'", false);
        //Debug.Log(role);
        //_personalRoleOne.text = $"Должность: {SqlQuery.ExecuteQuerySelect($"SELECT roleName FROM Roles WHERE roleId = {Convert.ToInt32(role)}", false)}";

        //_personalNameTwo.text = SqlQuery.ExecuteQuerySelect($"SELECT fullName FROM Users WHERE userId = {Convert.ToInt32(resultArrayTimetable[1])}", false);
        //role = SqlQuery.ExecuteQuerySelect($"SELECT roleId FROM Users WHERE fullName = '{_personalNameTwo.text}'", false);
        //_personalRoleTwo.text = $"Должность: {SqlQuery.ExecuteQuerySelect($"SELECT roleName FROM Roles WHERE roleId = {Convert.ToInt32(role)}", false)}";

        //_dataText.text = $"Дата: {dateString}";
    }
}
