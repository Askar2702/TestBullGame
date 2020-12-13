using System.Collections;
using System.Collections.Generic;
public class MyStack <T> : IEnumerable
{
    /// <summary>
    /// первый элемент списка
    /// </summary>
    public Item<T> Head { get; private set; }


    /// <summary>
    /// последний эелмент списка
    /// </summary>
    public Item<T> Tail { get; private set; }

    /// <summary>
    /// количество элемента списка
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// создание пустокого списка
    /// </summary>
    public MyStack()
    {
        Clear();
    }
    
    /// <summary>
    /// создание  списка первым элементом 
    /// </summary>
    /// <param name="data"></param>
    public MyStack(T data)
    {
        SetHeadAndTail(data);
    }
    

    /// <summary>
    /// добавить данные в конец списка
    /// </summary>
    /// <param name="data"></param>
    public void Add(T data)
    {       
        if (Tail != null)
        {
            var item = new Item<T>(data);
            Tail.Next = item;
            Tail = item;
            Count++;
        }
        else SetHeadAndTail(data);
    }
    private void SetHeadAndTail(T data)
    {
        var item = new Item<T>(data);
        Head = item;
        Tail = item;
        Count = 1;
    }

    /// <summary>
    /// удаление первого элемента
    /// </summary>
    public void DeleteHead()
    {
        Head = Head.Next;
        Count--;
    }

    /// <summary>
    ///  удаление по значению
    /// </summary>
    /// <param name="item"></param>
    public void Delete(T item)
    {
        if (Head != null)
        {
            if (Head.Data.Equals(item))
            {
                Head = Head.Next;
                Count--;
                return;
            }
            var current = Head.Next;
            var previous = Head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    previous.Next = current.Next;
                    Count--;
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }
    }

    /// <summary>
    /// полное удаление всех элементов
    /// </summary>
    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    /// <summary>
    /// получение всех элементов списка
    /// </summary>
    /// <returns></returns>
    public IEnumerator GetEnumerator()
    {
        var current = Head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}
