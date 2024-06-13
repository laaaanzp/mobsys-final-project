using System;
using UnityEngine;

public class YesNoModalHandler : MonoBehaviour
{
    [SerializeField] private GameObject yesNoModalPrefab;

    private static YesNoModalHandler instance;


    void Awake()
    {
        instance = this;
    }

    public static void Open(string title, Action yesAction, Action noAction)
    {
        GameObject obj = Instantiate(instance.yesNoModalPrefab, instance.transform);
        YesNoModal yesNoModal = obj.GetComponent<YesNoModal>();

        yesNoModal.Open(title, yesAction, noAction);
    }
}
