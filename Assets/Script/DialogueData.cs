using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData : MonoBehaviour
{
    [System.Serializable]
    public class DialogueNode
    {
        public string speaker;
        [TextArea(3, 10)]
        public string dialogueText;
        public DialogueNode[] responses;
    }

    public DialogueNode[] dialogueNodes;
}
