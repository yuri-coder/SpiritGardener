using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoType : MonoBehaviour
{

    public float letterPause = 0.01f;
    public Text displayText;

    // Use this for initialization
    void Start()
    {
        //        StartCoroutine(TypeText());

    }

    public IEnumerator TypeText(string message)
    {
        foreach (char letter in message.ToCharArray())
        {
            displayText.text += letter;

            yield return 0;
            //yield return new WaitForSeconds(letterPause);
        }
    }
}
