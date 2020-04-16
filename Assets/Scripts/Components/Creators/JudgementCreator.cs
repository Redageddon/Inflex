using System;
using UnityEngine;
using UnityEngine.UI;

public class JudgementCreator : MonoBehaviour
{
    public static void Create(double hitObjectRotation)
    {
        double accuracy = Grade(hitObjectRotation);

        GameObject judgement = GameObject.Find("Canvas").transform.Find("Judgement").gameObject;
        
        GameObject newJudgement = Instantiate(judgement, judgement.transform.parent, false);
        newJudgement.GetComponent<Text>().color = Color.HSVToRGB((float)accuracy/100,1,1, true);
        newJudgement.GetComponent<Text>().text = accuracy.ToString();
        newJudgement.SetActive(true);
        Destroy(newJudgement, 0.15f);
    }

    private static double Grade(double hitObjectRotation)
    {
        const int grader = 15;
        
        double truePointerRotation = FixPointerRotation(Pointer.GetZRotation(), hitObjectRotation);
        
        if (Math.Abs(truePointerRotation - hitObjectRotation) < grader)
        {
            return Math.Round(100 * (Math.Abs(truePointerRotation - hitObjectRotation) - grader) / -grader);
        }

        return 0d;
    }

    private static double FixPointerRotation(double pointerRotation, double hitObjectRotation)
    {
        if (pointerRotation - hitObjectRotation > 100)
        {
            return pointerRotation -= 360;
        }

        return pointerRotation;
    }
}