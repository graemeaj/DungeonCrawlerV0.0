using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Inventory backpack;// = new Inventory();
    public float maxSpeed = 5f;
    public float slowDownFactor = 0.8f;




    public void move()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * maxSpeed, 1 * maxSpeed);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * maxSpeed, 1 * maxSpeed);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * maxSpeed, -1 * maxSpeed);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * maxSpeed, -1 * maxSpeed);
        }
        else if (Input.GetKey(KeyCode.W))//up
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1 * maxSpeed);
        }
        else if (Input.GetKey(KeyCode.S))//down
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * maxSpeed);
        }
        else if (Input.GetKey(KeyCode.A))//left
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * maxSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D))//right
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * maxSpeed, 0);
        }
		else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * maxSpeed* slowDownFactor, 1 * maxSpeed* slowDownFactor);
        }
		else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(1 * maxSpeed* slowDownFactor, 1 * maxSpeed* slowDownFactor);
		}
		else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(1 * maxSpeed* slowDownFactor, -1 * maxSpeed* slowDownFactor);
		}
		else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * maxSpeed* slowDownFactor, -1 * maxSpeed* slowDownFactor);
		}
		else if(Input.GetKey(KeyCode.W))//up
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1 * maxSpeed* slowDownFactor);
		}
		else if(Input.GetKey(KeyCode.S))//down
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * maxSpeed* slowDownFactor);
		}
		else if(Input.GetKey(KeyCode.A))//left
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * maxSpeed* slowDownFactor, 0);
		}
		else if(Input.GetKey(KeyCode.D))//right
		{
		    GetComponent<Rigidbody2D>().velocity = new Vector2(1 * maxSpeed* slowDownFactor, 0);
		}
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }






    void Awake()
    {
        backpack = gameObject.AddComponent<Inventory>();
    }

	void Start () {
        Item random_item = gameObject.AddComponent<Item>();
        random_item.name = "a shiny sword";
        random_item.type = "weapon";
        random_item.image_type = "bow";
        backpack.add_to_inventory(random_item);
        Item random_item2 = gameObject.AddComponent<Item>();
        random_item2.name = "a shiny axe";
        random_item2.type = "weapon";
        random_item2.image_type = "axe";
        backpack.add_to_inventory(random_item2);
        Item random_item3 = gameObject.AddComponent<Item>();
        random_item3.name = "a shiny bow";
        random_item3.type = "weapon";
        random_item3.image_type = "bow";
        backpack.add_to_inventory(random_item3);
    }
	
	// Update is called once per frame
	void Update () {
        move();
    }
}
