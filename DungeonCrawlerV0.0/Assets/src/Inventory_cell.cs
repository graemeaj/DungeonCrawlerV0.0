using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Inventory_cell : MonoBehaviour {

    Item cell_item;
    public GameObject player_g_o;
    Player player;
    //GameObject player_game_object;
    public int array_x;
    public int array_y;



    public void update_inventory_cells()
    {
        //Debug.Log(cell_item.image_type);
        if(cell_item.name == "")
        {
            //null cell
        }
        else if (cell_item.image_type == "consumable")
        {
            transform.FindChild("Image").GetComponent<Image>().overrideSprite = (Sprite)Resources.Load("art/sword.png");
        }
        else if (cell_item.image_type == "sword")
        {
            transform.FindChild("Image").GetComponent<Image>().sprite = Resources.Load("art/sword", typeof(Sprite)) as Sprite;
        }
        else if (cell_item.image_type == "mace")
        {
            transform.FindChild("Image").GetComponent<Image>().sprite = Resources.Load("art/mace", typeof(Sprite)) as Sprite;
        }
        else if (cell_item.image_type == "axe")
        {
            transform.FindChild("Image").GetComponent<Image>().sprite = Resources.Load("art/axe", typeof(Sprite)) as Sprite;
        }
        else if (cell_item.image_type == "bow")
        {
            transform.FindChild("Image").GetComponent<Image>().sprite = Resources.Load("art/bow", typeof(Sprite)) as Sprite;
        }
        else if (cell_item.image_type == "dagger")
        {
            transform.FindChild("Image").GetComponent<Image>().sprite = Resources.Load("art/dagger", typeof(Sprite)) as Sprite;
        }
        transform.FindChild("Image").GetComponent<Image>().color = new Color32(155, 155, 155, 255);

        
    }

	// Use this for initialization
	void Start () {
        player_g_o = GameObject.Find("/Player");
        player = player_g_o.GetComponent<Player>();
        //Debug.Log(GameObject.Find("Player").GetComponent<Player>().backpack.inventory_store[0, 0].type);
        cell_item = player.backpack.inventory_store[array_x, array_y];
        update_inventory_cells();


        
    }
	
	// Update is called once per frame
	void Update () {
        update_inventory_cells();
    }
}
