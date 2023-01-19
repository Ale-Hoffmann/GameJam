using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTeste : MonoBehaviour
{
    public GameObject player;
    public Vector3 dist;
   
    
        
  
    void Update()
    {


        transform.position = player.transform.position + dist;
       
        transform.LookAt(player.transform);

    }

  
}
