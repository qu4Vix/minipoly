using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public int state;

    // Start is called before the first frame update
    void Start()
    {
        tossDice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void tossDice()
    {
        state = Random.Range(0, 7);
    }
}
