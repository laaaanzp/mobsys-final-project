using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private GameObject[] lifeImages;
    private static Life instance;


    void Awake()
    {
        instance = this;
        RenderLife();
    }

    private void RenderLife()
    {
        int life = Database.GetPlayerLife();

        foreach (GameObject lifeImage in lifeImages)
        {
            lifeImage.SetActive(false);
        }

        for (int i = 0; i < life; i++)
        {
            lifeImages[i].SetActive(true);
        }
    }

    public static void Deduct()
    {
        Database.RemovePlayerLife();
        instance.RenderLife();
    }
}
