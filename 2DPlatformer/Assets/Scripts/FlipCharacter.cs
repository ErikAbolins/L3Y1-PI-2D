using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    public PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float inputs = playerController.inputs;
        if (inputs > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (inputs < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

}
