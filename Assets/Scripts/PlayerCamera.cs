using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    public bool cutscene = false;
    public int distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PC");
        distance = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(!cutscene)
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - distance);
    }

    void endCutscene()
    {
        cutscene = false;
    }

    void startCutscene()
    {
        cutscene = true;
    }
}
