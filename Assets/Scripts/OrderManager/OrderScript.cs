using DatabaseManager;
using DataUser;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace OrderManager
{
    public class OrderScript : MonoBehaviour
    {
        [SerializeField] private GameObject _newListObj;

        [SerializeField] private Transform _contentTransforOrder;

        private List<string> resultArrayListDate = new List<string>();
        private List<string> resultArrayOrderList = new List<string>();

        public void ElementDisplayOrderList()
        {
            List<string> resultArrayIdList = new List<string>(SqlQuery.ExecuteQuerySelect($"SELECT dayId FROM Timetables WHERE userId = '{UserDataApplication.userId}'", true).Split(';'));

           SpawnElementOrder(resultArrayIdList);
        }

        private void ExecuteElementOrderQuery(string result, GameObject ListObj)
        {
            ListObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = result;
            ListObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT title FROM Orders WHERE orderId = '{result}'", false);
            ListObj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT description FROM Contents WHERE orderId = '{result}'", false);
            ListObj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT dateOrder FROM Orders WHERE orderId ='{result}'", false);
            ListObj.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT count FROM Orders WHERE orderId = '{result}'", false);
            ListObj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT status FROM Orders WHERE orderId = '{result}'", false);
        }

        private void SpawnElementOrder(List<string> resultArrayIdList)
        {
            foreach (string id in resultArrayIdList)
            {
                Debug.Log(id);
                string date = SqlQuery.ExecuteQuerySelect($"SELECT date FROM Days WHERE dayId = '{id}'", false);
                resultArrayListDate.Add(date);
            }

            foreach (string item in resultArrayListDate)
            {
                string id = SqlQuery.ExecuteQuerySelect($"SELECT orderId FROM Orders WHERE dateOrder = '{item}'", false);
                resultArrayOrderList.Add(id);
            }

            foreach (string order in resultArrayOrderList)
            {
                if (order != "")
                {
                    GameObject ListObj = Instantiate(_newListObj, _contentTransforOrder.position, Quaternion.identity);
                    ListObj.transform.SetParent(_contentTransforOrder);

                    ExecuteElementOrderQuery(order, ListObj);
                }
            }
        }

        public void DestroyElemntOrder()
        {
            foreach (Transform item in _contentTransforOrder)
            {
                Destroy(item.gameObject);
            }

            resultArrayOrderList.Clear();
            resultArrayListDate.Clear();
        }
    }
}
