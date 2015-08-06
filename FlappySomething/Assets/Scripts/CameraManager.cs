using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public GameObject player;
    float x,y,z;

	// Use this for initialization
	void Start () {
        y = this.transform.position.y;
        z = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

        x = player.transform.position.x;
        this.transform.position = new Vector3(x, y, z);
	}
}
