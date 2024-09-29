using System;
using System.Collections.Generic;

public struct AiActionWeight
{
    public AiAction aiAction { get; private set; }
    public int weight { get; private set; }

    public AiActionWeight(AiAction aiAction, int weight)
    {
        this.aiAction = aiAction;
        this.weight = weight;
    }
}

public class MonsterAiComponent
{
    private List<AiActionWeight> actionWeightList;
    private int maxWeight = 0;

    public MonsterAiComponent()
    {
        actionWeightList = new List<AiActionWeight>();
    }

    public void RemoveActions()
    {
        actionWeightList.Clear();
    }

    public void AddActionWeight(AiAction aiAction, int weight)
    {
        actionWeightList.Add(new AiActionWeight(aiAction, weight));
        maxWeight += weight;
    }

    public AiAction NextAiAction()
    {
        int nextActionWeight = new Random().Next(0, maxWeight);
        int currentWeight = 0;
        foreach (AiActionWeight weight in actionWeightList)
        {
            currentWeight += weight.weight;
            if (nextActionWeight < currentWeight)
            {
                return weight.aiAction;
            }
        }
        return null;
    }
}