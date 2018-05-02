using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager Instance;


    public GameObject speakerDialogue;
    public GameObject mainDialogue;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayDialogue(ScriptableDialogue dialogue)
    {
        StopAllCoroutines();
        speakerDialogue.GetComponent<Text>().text = "";
        StartCoroutine(speakerDialogue.GetComponent<AutoType>().TypeText(dialogue.speaker));
        mainDialogue.GetComponent<Text>().text = "";
        StartCoroutine(mainDialogue.GetComponent<AutoType>().TypeText(dialogue.dialogue));
    }

    public void DisplayMessage(string message)
    {
        StopAllCoroutines();
        print("In DisplayMessage");
        print("String is : " + message);
        mainDialogue.GetComponent<Text>().text = "";
        StartCoroutine(mainDialogue.GetComponent<AutoType>().TypeText(message));
        if(speakerDialogue.GetComponent<Text>().text != "System")
        {
            speakerDialogue.GetComponent<Text>().text = "";
            StartCoroutine(speakerDialogue.GetComponent<AutoType>().TypeText("System"));
        }
    }

}
