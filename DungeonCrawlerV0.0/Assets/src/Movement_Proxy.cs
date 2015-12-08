using UnityEngine;
using System.Collections;

public class Movement_Proxy : MonoBehaviour {
    public Item incoming_item_storage;
    public Item receiving_item_storage;
    public bool is_down = false;
    public Player player;

    public int incoming_backpack_x;
    public int incoming_backpack_y;
    public int receiving_backpack_x;
    public int receiving_backpack_y;

    void start()
    {
        incoming_item_storage = null;
        receiving_item_storage = null;
    }




}
