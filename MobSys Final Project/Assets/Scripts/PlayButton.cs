using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void OnPress()
    {
        if (Database.HasPlayerData())
        {
            PlayModal.Open();
        }
        else
        {
            Database.Restart();
            SceneSwitcher.LoadScene(SceneIndex.LEVEL);
        }
    }
}
