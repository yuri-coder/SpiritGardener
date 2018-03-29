using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSeed : Seed
{

    //protected int itemID;
    //protected string itemName, description;
    public new static int itemID = 201;
    public new static string itemName = "Basic Seed";
    public new static string description = "A small miracle of life! Grows into Beginner Grass.";

    private void Awake()
    {
        //itemID = 101;
        //itemName = "Basic Essence";
        //description = "An inert, easily gathered essence that all fledgling Spirit Gardeners train their siphoning with.";
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
