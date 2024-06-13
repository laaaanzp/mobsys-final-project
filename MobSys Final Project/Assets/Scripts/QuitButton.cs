using UnityEditor;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnPress()
    {
        YesNoModalHandler.Open("Quiz Game?", QuitGame, null);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
