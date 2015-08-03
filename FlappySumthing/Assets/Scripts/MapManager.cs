using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

    public GameObject pipePrefab,
                      player;
    float x,y,z;
    public float rate = 10;

	// Use this for initialization
	void Start () {
        Vector3 pos = this.transform.position;
        y = pos.y;
        z = pos.z;
        StartCoroutine(CreatePipes(rate));
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        //        if (player.transform.position.x % scale < 0.1f)
	}

    void Move()
    {
        x = player.transform.position.x;
        this.transform.position = new Vector3(x, y, z);
    }

    IEnumerator CreatePipes(float time)
    {
        while (true)
        {   
        float rand = Random.Range(-3, 4);
        Vector3 pos = new Vector3(player.transform.position.x +13,rand,z);
        GameObject.Instantiate(pipePrefab, pos, pipePrefab.transform.rotation);
        yield return new WaitForSeconds(time);
        }
    }
}
