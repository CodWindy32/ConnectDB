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

        [SerializeField] private Transform _contentTransform;

        List<string> resultArrayListDate = new List<string>();
       public List<string> resultArrayOrderList = new List<string>();

        public void ElementDisplayPersonalList()
        {
            Debug.Log(UserDataApplication.userId);
            List<string> resultArrayIdList = new List<string>(SqlQuery.ExecuteQuerySelect($"SELECT dayId FROM Timetables WHERE userId = '{UserDataApplication.userId}'", true).Split(';'));

            foreach (string id in resultArrayIdList)
            {
                string date = SqlQuery.ExecuteQuerySelect($"SELECT date FROM Days WHERE dayId = '{id}'", false);
                resultArrayListDate.Add(date);
            }

            foreach (string item in resultArrayListDate)
            {
                string id = SqlQuery.ExecuteQuerySelect($"SELECT orderId FROM Orders WHERE dateOrder = '{item}'", false);
                resultArrayOrderList.Add(id);
            }

            foreach (string result in resultArrayOrderList)
            {
                GameObject ListObj = Instantiate(_newListObj, _contentTransform.position, Quaternion.identity);
                ListObj.transform.SetParent(_contentTransform);

                ExecuteElementPersonalQuery(result, ListObj);
            }

           
        }

        private void ExecuteElementPersonalQuery(string result, GameObject ListObj)
        {
            ListObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = result;
            ListObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT title FROM Orders WHERE orderId = '{result}'", false);
            ListObj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT description FROM Contents WHERE orderId = '{result}'", false);
            ListObj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT dateOrder FROM Orders WHERE orderId ='{result}'", false);
            ListObj.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT count FROM Orders WHERE orderId = '{result}'", false);
            ListObj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT status FROM Orders WHERE orderId = '{result}'", false);
        }

        public void DestroyElemntPersonal()
        {
            foreach (Transform item in _contentTransform)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
