using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathPro : MonoBehaviour
{
    public int GResult;
    public int CountSum;
    public int AllSum;  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Add()
    //G�Լ��� ���� ���� ���ϴ� ����
    {
        CountSum = CountSum + GResult;
    }
    public void All()
    //2~5000������ ����
    {
        for (int i = 2; i < 5000; i++)
        {
            AllSum = AllSum + i;
        }
    }
    public void Generater()
    //G�Լ��� ������ ��
    {

    }
    public void Int2Char(int a)
    //G�Լ��� ���� �� �ڸ����� �����ϰ� ���� ����
    {
        //int a
    }
}
