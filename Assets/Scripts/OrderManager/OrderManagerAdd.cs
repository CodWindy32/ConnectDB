using UnityEngine;
using TMPro;
using DatabaseManager;
using System;

namespace OrderManager
{
    public class OrderManagerAdd : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputName;
        [SerializeField] private TMP_InputField _inputDesc;
        [SerializeField] private TMP_InputField _inputDate;
        [SerializeField] private TMP_InputField _inputClient;

        public void AddOrder()
        {
            SqlQuery.ExecuteQueryEditing($"INSERT INTO Orders (title, dateOrder, status, count) VALUES ('{_inputName.text}', '{_inputDate.text}', 'принят', '{Convert.ToInt32(_inputClient.text)}')");

            string idOrder = SqlQuery.ExecuteQuerySelect($"SELECT orderId FROM Orders WHERE title = '{_inputName.text}'", false);
            SqlQuery.ExecuteQueryEditing($"INSERT INTO Contents (description, orderId) VALUES ('{_inputDesc.text}', '{Convert.ToInt32(idOrder)}')");
        }
    }
}
