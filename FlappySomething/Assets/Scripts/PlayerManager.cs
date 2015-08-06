using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public Text scoreText,gameover;
    Vector2 velocity;
    int score = 0;

	// Use this for initialization
	void Start () {
        this.transform.position = Vector3.zero;
        velocity = Vector2.zero;    //  = Vector2(0,0);
	}
	
	// Update is called once per frame
	void Update () {
        //  move
        this.transform.Translate(velocity);

        //  jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.x = 0.1f;
            velocity.y = 0.1f;
        }

        //  downforce
        if (velocity.x > 0)
        {
            velocity.y -= 0.005f;
        }

        //  restart
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel(0);
        }
	}


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            gameover.gameObject.SetActive(true);
            velocity = new Vector2(0, 0);
        }
        else if (other.gameObject.tag == "point")
        {
            score++;
            scoreText.text = "SCORE : " + score;
        }
    }
}
