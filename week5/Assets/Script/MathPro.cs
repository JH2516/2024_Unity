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
    //G함수로 나온 값을 합하는 과정
    {
        CountSum = CountSum + GResult;
    }
    public void All()
    //2~5000까지의 총합
    {
        for (int i = 2; i < 5000; i++)
        {
            AllSum = AllSum + i;
        }
    }
    public void Generater()
    //G함수로 나오는 값
    {

    }
    public void Int2Char(int a)
    //G함수를 위해 각 자릿수를 분해하고 합한 과정
    {
        //int a
    }
}
