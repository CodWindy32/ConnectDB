using DatabaseManager;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace PersonalList
{
    public class PersonalService : MonoBehaviour
    {
        [SerializeField] private GameObject _newListObj;

        [SerializeField] private Transform _contentTransform;

        public void ElementDisplayPersonalList()
        {
            List<string> resultArrayPersonalList = new List<string>(SqlQuery.ExecuteQuerySelect($"SELECT userId FROM Users", true).Split(';'));

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
            ListObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT fullName FROM Users WHERE userId = '{result}'", false);
            ListObj.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT age FROM Users WHERE userId ='{result}'", false);
            string roleId = SqlQuery.ExecuteQuerySelect($"SELECT roleId FROM Users WHERE userId = '{Convert.ToInt32(result)}'", false);
            ListObj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = SqlQuery.ExecuteQuerySelect($"SELECT roleName FROM Roles WHERE roleId = {Convert.ToInt32(roleId)}", false);
            ListObj.transform.GetChild(8).GetComponent<Button>().onClick.AddListener(delegate
            {
                OnDeletePersonal(result);
            });
        }

        public void DestroyElemntPersonal()
        {
            foreach (Transform item in _contentTransform)
            {
                Destroy(item.gameObject);
            }
        }

        public void OnDeletePersonal(string result)
        {
            SqlQuery.ExecuteQueryEditing($"DELETE FROM Users WHERE userId = {result};");
            DestroyElemntPersonal();
            ElementDisplayPersonalList();
        }
    }
}
