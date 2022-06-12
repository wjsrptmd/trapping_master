using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public GameObject girl;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        girl.GetComponent<girl>().SetBall(ball);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
