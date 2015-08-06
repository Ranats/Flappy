using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BgManager : MonoBehaviour {

    public GameObject[] bg1, bg2;

    GameObject[][] backgrounds;

    Vector3 nextBgPos;
    bool startFlg;

	// Use this for initialization
	void Start () {
        startFlg = false;
        nextBgPos = bg2[0].transform.localPosition;
        backgrounds = new GameObject[][]{bg1,bg2};
        for (int i = 0; i < bg1.Length; i++)
        {
            bg1[i].transform.SetSiblingIndex(i*2);
            bg2[i].transform.SetSiblingIndex(i*2+1);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startFlg = true;
        }
        if (startFlg)
        {
            BGScroller();
        }
	}

    void BGScroller()
    {
        for (int j = 0; j < backgrounds.Length; j++)
        {
            for (int i = 0; i < bg1.Length; i++)
            {
                if (backgrounds[j][i].GetComponent<RectTransform>().localPosition.x <= -Screen.width / 2)
                {
                    nextBgPos.y = backgrounds[j][i].transform.localPosition.y;
                    backgrounds[j][i].transform.localPosition = nextBgPos;
                }
                backgrounds[j][i].transform.localPosition += Vector3.left * (i + 1) * 5;
            }
        }
    }

}
