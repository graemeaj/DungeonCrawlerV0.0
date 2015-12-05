using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inventory_tile_mouse_interaction : MonoBehaviour {

    private bool is_held_down = false;//is the mouse button held down
    private bool is_over = false;//is the the mouse over the image
    private bool holding = false;//is the user holding the item

    Vector3 temp;//temp vector for placing the image in a different spot
    Vector3 original_location;

    void Start()
    {
        gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
        original_location = gameObject.transform.position;
        //original_location.z = -1.0f;
        Debug.Log(original_location);
        
    }

    void OnMouseOver()
    {
        is_over = true;
        if (is_held_down == false)
        {
            if (gameObject.GetComponent<Image>().sprite == null)
            {
                gameObject.GetComponent<Image>().color = new Color32(190, 190, 190, 255);
            }
            else
            {
                gameObject.GetComponent<Image>().color = Color.red;
            }
        }

        
    }

    void OnMouseExit()
    {
        is_over = false;
        gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
    }

    void OnMouseDown()
    {
        Debug.Log(this.transform.parent.GetComponent<Inventory_cell>().cell_item.image_type);
        if (this.transform.parent.GetComponent<Inventory_cell>().cell_item.image_type != "")
        {
            Debug.Log("hello there");
            gameObject.GetComponent<Image>().color = Color.blue;
            is_held_down = true;
            if (is_held_down == true && is_over == true)
            {
                holding = true;
                this.GetComponent<Canvas>().sortingOrder = 2;
            }
        } 
    }

    void OnMouseUp()
    {
        Debug.Log("hello there dropped");
        //gameObject.GetComponent<Image>().color = Color.blue;
        is_held_down = false;
        holding = false;
        gameObject.transform.position = original_location;
        this.GetComponent<Canvas>().sortingOrder = 1;
    }

    void LateUpdate()
    {
        if (Input.GetButton("Fire1") && holding == true)
        {
            temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            temp.z = 1.0f;
            Debug.Log(temp);

            gameObject.transform.position = temp;
        }
    }
}
