using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    private List<T> items = new List<T>();
    public void Initialize()
    {

        items.Clear();
    }
    public T GetItemIndex(int index)
    {
        return items[0];
    }

    public void AddToList(T itemToAdd)
    {
        if (!items.Contains(itemToAdd))
        {
            items.Add(itemToAdd);
        }
    }

    public void RemoveFromList(T itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
        }
    }
}
