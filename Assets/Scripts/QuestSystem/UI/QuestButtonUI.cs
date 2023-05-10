using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestButtonUI : MonoBehaviour
{
    [SerializeField] public QuestSO questSO;
    [SerializeField] private Image questIconSlot;
    [SerializeField] private TextMeshProUGUI questNameSlot;
    private Button questButton;

    private void Awake() {
        questButton = this.GetComponent<Button>();
    }

    private void Start() {
        questButton.onClick.AddListener(() => {
            QuestLogUIController.Instance.UpdateQuestLogContent(questSO);
        });
    }

    public void UpdateButtonVisual() {
        questIconSlot.sprite = questSO.GetQuestItemSO().GetItemIcon();
        questNameSlot.text = questSO.GetQuestName();
    }


}
