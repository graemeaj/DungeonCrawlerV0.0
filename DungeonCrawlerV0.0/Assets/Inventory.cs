using UnityEngine;
using System.Collections;
using System;

public class Inventory : MonoBehaviour {
    Item[,] inventory_store = new Item[10,10];
    // Use this for initialization
    void Start () {
	    for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                Item test = gameObject.AddComponent<Item>();
                test.name = "hello";
                inventory_store[i, j] = test;
                Debug.Log(inventory_store[i, j].name);
                Destroy(test);
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
