using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Button[] responseButtons;

    private int currentNodeIndex = 0;
    private DialogueData.DialogueNode currentNode;

    public void StartDialogue(DialogueData dialogueData)
    {
        currentNodeIndex = 0;
        DisplayDialogue(dialogueData.dialogueNodes[currentNodeIndex]);
    }

    public void ContinueDialogue(int responseIndex)
    {
        if (currentNode.responses != null && responseIndex < currentNode.responses.Length)
        {
            currentNodeIndex = responseIndex;
            DisplayDialogue(currentNode.responses[currentNodeIndex]);
        }
        else
        {
            EndDialogue();
        }
    }

    private void DisplayDialogue(DialogueData.DialogueNode node)
    {
        currentNode = node;
        dialogueText.text = $"{node.speaker}: {node.dialogueText}";

        // Display response buttons if available
        for (int i = 0; i < responseButtons.Length; i++)
        {
            if (node.responses != null && i < node.responses.Length)
            {
                responseButtons[i].gameObject.SetActive(true);
                responseButtons[i].GetComponentInChildren<Text>().text = node.responses[i].dialogueText;
            }
            else
            {
                responseButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void EndDialogue()
    {
        // Additional logic when the dialogue ends (e.g., close UI, trigger events)
        Debug.Log("End of dialogue.");
    }
}

