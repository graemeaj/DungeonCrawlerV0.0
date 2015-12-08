using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inventory_tile_mouse_interaction : MonoBehaviour {

    private bool is_held_down = false;//is the mouse button held down
    private bool is_over = false;//is the the mouse over the image
    private bool holding = false;//is the user holding the item
    private bool dropped = false;//if the user drops the item

    public Movement_Proxy selection_storage;

    private Item empty_item = new Item();

    Vector3 temp;//temp vector for placing the image in a different spot
    Vector3 original_location;
    Vector3 original_scale;

    void Start()
    {
        gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
        original_location = gameObject.transform.position;
        //original_location.z = -1.0f;
        original_scale = this.gameObject.transform.localScale;

    }

    void OnMouseOver()
    {
        is_over = true;


        if (gameObject.GetComponent<Image>().sprite == null)
        {
            gameObject.GetComponent<Image>().color = new Color32(190, 190, 190, 255);
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
        if (selection_storage.is_down == true && this.transform.parent.GetComponent<Inventory_cell>().cell_item.image_type != "")
        {
            selection_storage.receiving_item_storage = this.transform.parent.GetComponent<Inventory_cell>().cell_item;
            selection_storage.receiving_backpack_x = this.transform.parent.GetComponent<Inventory_cell>().array_x;
            selection_storage.receiving_backpack_y = this.transform.parent.GetComponent<Inventory_cell>().array_y;
            Debug.Log(selection_storage.receiving_item_storage.image_type);
        }
        else if (this.transform.parent.GetComponent<Inventory_cell>().cell_item.image_type == "")
        {
            selection_storage.receiving_item_storage = this.transform.parent.GetComponent<Inventory_cell>().cell_item;
            selection_storage.receiving_backpack_x = this.transform.parent.GetComponent<Inventory_cell>().array_x;
            selection_storage.receiving_backpack_y = this.transform.parent.GetComponent<Inventory_cell>().array_y;
        }
    }

    void OnMouseExit()
    {
        is_over = false;
        gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
        selection_storage.receiving_item_storage = null;
    }

    void OnMouseDown()
    {
        if (this.transform.parent.GetComponent<Inventory_cell>().cell_item.image_type != "")
        {
            gameObject.GetComponent<Image>().color = Color.blue;
            selection_storage.is_down = true;
            is_held_down = true;
            selection_storage.incoming_item_storage = this.transform.parent.GetComponent<Inventory_cell>().cell_item;
            selection_storage.incoming_backpack_x = this.transform.parent.GetComponent<Inventory_cell>().array_x;
            selection_storage.incoming_backpack_y = this.transform.parent.GetComponent<Inventory_cell>().array_y;
            if (is_held_down == true && is_over == true)
            {
                holding = true;
                this.GetComponent<Canvas>().sortingOrder = 2;
                this.gameObject.transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
            }
        } 
    }


    void OnMouseUp()
    {
        if(holding == true)
        {
            dropped = true;
        }

        selection_storage.is_down = false;
        holding = false;
        if(selection_storage.incoming_item_storage == null || selection_storage.receiving_item_storage == null)
        {
            gameObject.transform.position = original_location;
            selection_storage.receiving_item_storage = null;
            selection_storage.incoming_item_storage = null;
            Debug.Log("drop failed");
        }
        else
        {
            if (selection_storage.incoming_item_storage.image_type != "")
            {
                Debug.Log("drop succeded");
                gameObject.transform.position = original_location;
                selection_storage.player.backpack.inventory_store[selection_storage.receiving_backpack_x, selection_storage.receiving_backpack_y] = selection_storage.incoming_item_storage;
                selection_storage.player.backpack.inventory_store[selection_storage.incoming_backpack_x, selection_storage.incoming_backpack_y] = selection_storage.receiving_item_storage;
                this.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
                selection_storage.receiving_item_storage = null;
                selection_storage.incoming_item_storage = null;
            }
            else
            {
                Debug.Log("drop succeded");
                gameObject.transform.position = original_location;
                selection_storage.player.backpack.inventory_store[selection_storage.receiving_backpack_x, selection_storage.receiving_backpack_y] = selection_storage.incoming_item_storage;
                selection_storage.player.backpack.inventory_store[selection_storage.incoming_backpack_x, selection_storage.incoming_backpack_y] = empty_item;
                this.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
                selection_storage.receiving_item_storage = null;
                selection_storage.incoming_item_storage = null;
            }
        }


        this.GetComponent<Canvas>().sortingOrder = 1;
        this.gameObject.transform.localScale = original_scale;
    }

    void LateUpdate()
    {
        if (Input.GetButton("Fire1") && holding == true)
        {
            //temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            temp.z = 1.0f;
            temp.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 5.0f;
            temp.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 5.0f;
            gameObject.transform.position = temp;
        }
    }
}
