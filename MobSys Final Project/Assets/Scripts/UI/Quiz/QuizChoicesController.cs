using UnityEngine;

public class QuizChoicesController : MonoBehaviour
{
    [SerializeField] private QuizChoice choiceA;
    [SerializeField] private QuizChoice choiceB;
    [SerializeField] private QuizChoice choiceC;
    [SerializeField] private QuizChoice choiceD;


    public void Initialize(QuizChoiceData data1, QuizChoiceData data2, QuizChoiceData data3, QuizChoiceData data4)
    {
        choiceA.Initialize(data1);
        choiceB.Initialize(data2);
        choiceC.Initialize(data3);
        choiceD.Initialize(data4);
    }
}
