using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "green")
        {
            ScoreManager.Instance.UpdateScore(10);

        }
        if (col.gameObject.tag == "red")
        {
            ScoreManager.Instance.UpdateScore(-7);

        }
    }
}
