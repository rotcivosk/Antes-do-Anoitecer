using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewEvents", menuName = "Events")]
public class EventsHandler : ScriptableObject
{
    public int id;
    [SerializeField] public string eventsName;
    [TextArea(4,5)]
    public string eventsDescription;

    [Header("Action 1")]
    [Space(10)]
    [TextArea(2,5)]
    [SerializeField] public string actionDescription1;
    [SerializeField] EventRequirement requirementAction1;

    [TextArea(2,5)]
    [SerializeField] public string[] resultDescription1 = new string[1];
    [SerializeField] public EventResult[] resultAction1 = new EventResult[1];
    [SerializeField] public  int[] chanceForEachResult1 = new int[1] { 100 };

    [Header("Action 2")]
    [Space(10)]
    [TextArea(2,5)]
    [SerializeField] public  string actionDescription2;
    [SerializeField] EventRequirement requirementAction2;

    [TextArea(2,5)]
    [SerializeField] public  string[] resultDescription2 = new string[1];
    [SerializeField] EventResult[] resultAction2 = new EventResult[1];
    [SerializeField]  public int[] chanceForEachResult2 = new int[1] { 100 };


    [Header("Action 3")]
    [Space(10)]
    [TextArea(2,5)]
    [SerializeField]  public string actionDescription3;
    [SerializeField] EventRequirement requirementAction3;

    [TextArea(2,5)]
    [SerializeField] public  string[] resultDescription3 = new string[1];
    [SerializeField] EventResult[] resultAction3 = new EventResult[1];
    [SerializeField] public  int[] chanceForEachResult3 = new int[1] { 100 };

}
