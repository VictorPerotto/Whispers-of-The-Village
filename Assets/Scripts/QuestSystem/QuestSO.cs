using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class QuestSO : ScriptableObject
{
    [SerializeField] private ItemSO questItemSO;
    [SerializeField] private string questName;
    [SerializeField, TextArea] private string questDescription;
    [SerializeField] private string questGiverName;
    [SerializeField] private string questEnderName;
    [SerializeField] private List<string> optionalQuestEnders;

    public ItemSO GetQuestItemSO() => questItemSO;
    public string GetQuestName() => questName;
    public string GetQuestDescription() => questDescription;
    public string GetQuestGiverName() => questGiverName;
    public string GetQuestEnderName() => questEnderName;
    public List<string> GetOptionalQuestEnders() => optionalQuestEnders;

}
