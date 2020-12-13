
/// <summary>
/// /Ячеика списка
/// </summary>
public class Item <T>
{
    private T data = default(T);
    /// <summary>
    /// данные хранимые в ячеике 
    /// </summary>
    public T Data
    {
        get { return data; }
        set
        {
            if (value != null)
                data = value;
        }
    }
    /// <summary>
    /// следующая ячеика списка
    /// </summary>
    public Item<T> Next { get; set; }

    public Item(T data)
    {
        Data = data;
    }
    public override string ToString()
    {
        return Data.ToString();
    }
}
