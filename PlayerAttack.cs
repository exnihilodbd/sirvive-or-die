using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator an;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClickButtonAttack()
    {
        if (!an.GetBool("move"))
        {
            an.SetTrigger("Attack");
        }
    }
    public void ClickButtonEmote()
    {
        if (!an.GetBool("move"))
        {
            an.SetTrigger("Pray");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
