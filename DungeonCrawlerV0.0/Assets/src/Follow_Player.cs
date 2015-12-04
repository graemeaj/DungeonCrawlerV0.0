using UnityEngine;
using System.Collections;

public class Follow_Player : MonoBehaviour {

    public Player selected_player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = this.transform.position - selected_player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = selected_player.transform.position + new Vector3(0, 0, -100);
	}
}
