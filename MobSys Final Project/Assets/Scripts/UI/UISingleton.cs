using UnityEngine;

public class UISingleton : MonoBehaviour
{
    private static GameObject instance;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance != null)
        {
            Destroy(instance.gameObject);
        }

        instance = gameObject;
    }
}
