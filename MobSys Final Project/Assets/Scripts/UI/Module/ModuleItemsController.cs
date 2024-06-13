using System.Collections.Generic;
using UnityEngine;

public class ModuleItemsController : MonoBehaviour
{
    private static ModuleItemsController instance;

    [SerializeField] private GameObject moduleItemPrefab;
    [SerializeField] private ModuleContentController moduleContentController;
    [SerializeField] private ModuleItem[] moduleItems;
    private Dictionary<string, ModuleItemButton> moduleItemButtons;


    void Awake()
    {
        instance = this;

    }
}
