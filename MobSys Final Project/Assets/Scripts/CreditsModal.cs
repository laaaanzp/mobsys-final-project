using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsModal : MonoBehaviour
{
    private static CreditsModal instance;


    void Awake()
    {
        instance = this;
        Close();
    }

    public static void Open()
    {
        instance.gameObject.SetActive(true);
    }

    public static void Close()
    {
        instance.gameObject.SetActive(false);
    }
}
