using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attech : MonoBehaviour
{
    public static Attech instance;

    public bool IsMusic, IsSound;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
