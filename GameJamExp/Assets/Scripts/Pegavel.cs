using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegavel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Tocou no player");
        }
        else
        {
            Debug.Log("algo me tocou");
        }
    }
}
