using UnityEngine;
using System;
using System.Collections.Generic;


[Serializable]
public class ScenarioResultData
{
    public float totalEvacuationTime;
    public bool decisionCorrect;
    public bool scenarioSuccess;
    public int currentDecision;

    public List<DecisionResult> decisionResults = new List<DecisionResult>();


}

//リストの中身
[Serializable]
public class DecisionResult
{
    public int decisionNumber;

    public bool isCorrect;

    public bool isTimeUp;

    public float responseTime;
}