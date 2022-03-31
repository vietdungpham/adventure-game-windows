using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsJumpCheck : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (player.grounded == false)
        {
            player.isJump = true;
            //player.canDoubleJump = true;
        }
        else
        {
            player.isJump = false;
            player.canDoubleJump = false;
        }
    }
}
