using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogUIController : MonoBehaviour
{
    public static QuestLogUIController Instance { get; private set; }

    [SerializeField] private GameObject questButtonPrefab;
    [SerializeField] private Transform questButtonContent;

    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI questFrom;
    [SerializeField] private TextMeshProUGUI questTo;
    [SerializeField] private TextMeshProUGUI questDescription;
    [SerializeField] private Transform questOptionalDeliveryContent;
    [SerializeField] private Transform optionalEnderPrefab;
    [SerializeField] private Image questIcon;


    private void Awake() 
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateQuestLogVisual();
        ClearQuestInfo();
        Hide();
    }

    public void UpdateQuestLogVisual()
    {   
        foreach(Transform questObj in questButtonContent)
        {
            Destroy(questObj.gameObject);
        }

        foreach (QuestSO quest in Player.Instance.GetQuestList())
        {
            GameObject newQuest = Instantiate(questButtonPrefab, questButtonContent);
            QuestButtonUI newQuestUI = newQuest.GetComponent<QuestButtonUI>();
            newQuestUI.questSO = quest;
            newQuestUI.UpdateButtonVisual();
        }
    }

    public void UpdateQuestLogContent(QuestSO quest) 
    {
        ClearContent();

        questName.text = quest.GetQuestName();
        questFrom.text = quest.GetQuestGiverName();
        questTo.text = quest.GetQuestEnderName();
        questDescription.text = quest.GetQuestDescription();
        questIcon.sprite = quest.GetQuestItemSO().GetItemIcon();

        for (int i = 0; i < quest.GetOptionalQuestEnders().Count; i++) 
        {
            Transform enderText = Instantiate(optionalEnderPrefab, questOptionalDeliveryContent);
            foreach (Transform child in enderText) 
            {
                TextMeshProUGUI childText = child.GetComponent<TextMeshProUGUI>();
                childText.text = quest.GetOptionalQuestEnders()[i];
            }
        }
    }

    private void ClearContent() 
    {
        foreach (Transform child in questOptionalDeliveryContent) 
        {
            GameObject childObj = child.gameObject;
            Destroy(childObj);
        }
    }

    private void ClearQuestInfo()
    {
        questName.text = "";
        questFrom.text = "";
        questTo.text = "";
        questDescription.text = "";
        questIcon.sprite = null;

        foreach (Transform child in questOptionalDeliveryContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void Show()  
    {
        this.gameObject.SetActive(true);
        ClearQuestInfo();
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
