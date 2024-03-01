using UnityEngine;
using DBManager;

public class TestQery : MonoBehaviour
{
    void Start()
    {
        SQLQuery.ExecuteQuerySelect("SELECT passwords FROM Users");
    }
}

