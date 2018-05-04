using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    public Vector3 curPosition;
    public Vector3 newPosition;
    public SpriteRenderer spriteRenderer;
    public float speed;

	// Use this for initialization
	void Start () {
        //print(gameObject.transform.position);
        newPosition = gameObject.transform.position;
        //speed = 10.0f;
        //canvas space speed = 42.2 * regular speed
        //gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, newPosition, speed * Time.deltaTime);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + (2.5f * Time.deltaTime));

    }

    public void MoveToLocation(Vector3 newLocation)
    {
        //DialogueManager.Instance.DisplayMessage("Moving to " + newLocation);
        //gameObject.transform.localPosition = newLocation;
        //gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;



        if (!gameObject.activeInHierarchy)
        {
            gameObject.transform.position = newLocation;
            newPosition = newLocation;
        }
        else
        {
            newPosition = newLocation;
        }


        gameObject.transform.position = newLocation;
        spriteRenderer.color = new Color32(255, 255, 255, 0);

    }
}
