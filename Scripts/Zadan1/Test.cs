using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private MyStack<int> stack;
    private List<float> vs;
    void Start()
    {
        stack = new MyStack<int>();
        stack.Add(1);
        stack.Add(3);
        stack.Add(2);
        foreach(var i in stack)
            print(i + " ");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
