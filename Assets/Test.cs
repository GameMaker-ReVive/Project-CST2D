using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public static int num;


    void Start()
    {
        Test first = new Test();
        Test second = new Test();

        first.SetNum(1);
        Debug.Log(first.GetNum());
        Debug.Log(second.GetNum());
        first.SetNum(2);
        Debug.Log(first.GetNum());
        Debug.Log(second.GetNum());
    }

    public void SetNum(int i)
    {
        num = i;
    }

    public int GetNum()
    {
        return num;
    }


}
