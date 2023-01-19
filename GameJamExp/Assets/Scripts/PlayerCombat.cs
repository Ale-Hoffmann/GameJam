using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    bool isHitting = false;
    float timer = 0f;
    public float timeHit;


    private Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { ani.SetTrigger("FirstHit"); isHitting = true; if (Input.GetKeyDown(KeyCode.E)) { ani.SetTrigger("SecondHit"); }}

        if(isHitting == true)
        {
            timer += 1 * Time.deltaTime;

            if (timer >= timeHit) { timer = 0; isHitting = false; }
           
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space)) { ani.SetTrigger("Roll"); }
        }
    }
}
