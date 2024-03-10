using DatabaseManager;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Order {
    public class OrderService : MonoBehaviour
    {
        [SerializeField] private GameObject _newListObj;

        [SerializeField] private Transform _contentTransform;

        public void ElementDisplayPersonalList()
        {
            List<string> resultArrayPersonalList = new List<string>(SqlQuery.ExecuteQuerySelect($"SELECT orderId FROM Orders", true).Split(';'));

            foreach (string result in resultArrayPersonalList)
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

