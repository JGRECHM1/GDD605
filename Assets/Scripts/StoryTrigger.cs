using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryTrigger : MonoBehaviour
{

    public Dialogue dialogue;


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }


}
