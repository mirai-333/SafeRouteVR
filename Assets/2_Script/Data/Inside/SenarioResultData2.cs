using UnityEngine;
using System.Collections.Generic;

public class SenarioResultData2
{
    public List<PhaseResult> phaseResults = new List<PhaseResult>();

    public float totalTime;

    public bool scenarioSuccess;
}

public class PhaseResult
{
    public int phaseNumber;

    public bool isSuccess;

    public float responseTime;
}