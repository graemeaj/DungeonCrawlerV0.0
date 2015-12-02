using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Inventory backpack;// = new Inventory();

    void Awake()
    {
        backpack = gameObject.AddComponent<Inventory>();
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
