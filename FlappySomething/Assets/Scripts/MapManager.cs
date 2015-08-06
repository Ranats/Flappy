using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

    public GameObject pipePrefab,
                      player;
    float x,y,z,height;
    public float rate = 10;

    Vector3 playerPos;

	// Use this for initialization
	void Start () {
        Vector3 pos = this.transform.position;
        y = pos.y;
        z = pos.z;
        playerPos = player.transform.localPosition;
        height = 0;
        //        StartCoroutine(CreatePipes(rate));
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();

        if (player.transform.localPosition.x - playerPos.x > rate)
        {
            print(player.transform.localPosition.x - playerPos.x);

            CreatePipe(height);
            playerPos = player.transform.localPosition;
        }
        //        if (player.transform.position.x % scale < 0.1f)
	}

    void Move()
    {
        x = player.transform.position.x;
        this.transform.position = new Vector3(x, y, z);
    }

    void CreatePipe(float y)
    {
        float rand = Random.Range(height-2, height+2);
        //  bottom < rand < top
        Mathf.Clamp(rand, -3, 4);
        Vector3 pos = new Vector3(player.transform.position.x + 13, rand, z);
        GameObject.Instantiate(pipePrefab, pos, pipePrefab.transform.rotation);
    }


    //  一定時間ごとじゃなくてPlayerのx座標をStart時に格納して、Player.transform.position.x - それ > rate(間隔)　でやっても良いかも
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
