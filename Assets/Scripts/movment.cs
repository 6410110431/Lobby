using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class movment : NetworkBehaviour
{

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float speed = 6f * Time.deltaTime;

        transform.Translate(new Vector2(moveHorizontal * speed, moveVertical * speed));

    }

}
