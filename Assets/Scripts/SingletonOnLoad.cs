using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonOnLoad : MonoBehaviour
{
    private static SingletonOnLoad instance;

    private void Start()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
