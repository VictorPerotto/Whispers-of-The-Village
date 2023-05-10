using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Object")]

public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Response[] responses;

    //para que o texto não seja acessivel diretamente pelas outras classes
    public string[] Dialogue => dialogue;    

    public bool HasResponses => Responses != null && Responses.Length > 0;

    public Response[] Responses => responses;
}