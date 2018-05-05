using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFader : MonoBehaviour {

    public int fadeIn; //1 = fade in, -1 = fade out (other = do nothing)
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(fadeIn == 1)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (2.5f * Time.deltaTime));
            if(text.color.a > 1.0f)
            {
                SetVisible();
                fadeIn = 0;
            }
        }
        else if(fadeIn == -1)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (2.5f * Time.deltaTime));
            if(text.color.a < 0.0f)
            {
                SetInvisible();
                fadeIn = 0;
            }
        }
	}

    public void SetInvisible()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
    }

    public void SetVisible()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
    }

    public void FadeIn()
    {
        fadeIn = 1;
    }

    public void FadeOut()
    {
        fadeIn = -1;
    }

}
