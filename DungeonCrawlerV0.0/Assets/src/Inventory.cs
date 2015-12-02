using UnityEngine;
using System.Collections;
using System;

public class Inventory : MonoBehaviour {
    public Item[,] inventory_store = new Item[4,7];
    // Use this for initialization

        void Awake()
    {
        Item test;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                test = gameObject.AddComponent<Item>();
                test.name = "hello, I'm row: " + i + " column: " + j;
                if (i == 2)
                {
                    test.image_type = "consumable";
                }
                else
                {
                    test.image_type = "weapon";
                }
                if(j == 0)
                {
                    test.image_type = "bow";
                }
                if (j == 1)
                {
                    test.image_type = "sword";
                }
                if (j == 3)
                {
                    test.image_type = "mace";
                }
                if (j == 4)
                {
                    test.image_type = "axe";
                }
                if (j == 5)
                {
                    test.image_type = "dagger";
                }
                test.is_null = false;
                inventory_store[i, j] = test;
                Debug.Log(test.name);
                Debug.Log(inventory_store[i, j].name);
            }

        }
    }


    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
