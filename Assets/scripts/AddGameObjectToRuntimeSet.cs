using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameObjectToRuntimeSet : MonoBehaviour
{
    public GameObjectRuntimeSet runtimeSet;
    public void OnEnable()
    {
        runtimeSet.AddToList(gameObject);
    }

    private void OnDisable()
    {
        runtimeSet.RemoveFromList(gameObject);
    }
}
