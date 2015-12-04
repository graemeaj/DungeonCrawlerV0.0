using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inventory_tile_mouse_interaction : MonoBehaviour {


    void OnMouseOver()
    {

        Debug.Log("hello");
        this.gameObject.GetComponent<Image>().color = Color.yellow;
    }

    void OnMouseExit()
    {
        Debug.Log("goodbye");
        this.gameObject.GetComponent<Image>().color = Color.white;
    }
}
