using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Monster
{   
    // Update is called once per frame
    protected override void Update()
    {
        PursuePlayer();
    }
}
