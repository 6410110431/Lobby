using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Playermove : NetworkBehaviour
{
    private void Update()
    {
        if (hasAuthority)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertival = Input.GetAxisRaw("Vertical");
            float speed = 6f * Time.deltaTime;
            transform.Translate(new Vector2(horizontal * speed, vertival * speed));
            
        }
    }
}
