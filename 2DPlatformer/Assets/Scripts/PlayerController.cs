using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text timerTxt;
    public float timer;

    [Header("Main")]
    private int extraJump;
    public int extraJumpValue;
    private float currentSpeed;
    public float sprintSpeed = 10f;
    public float moveSpeed;
    public float jumpForce;
    float inputs;
    public Rigidbody2D rb;
    public float groundDistance;
    public LayerMask layerMask;
    public float kbforce;
    public float kbCounter;
    public float kbTotalTime;
    public bool KnockFromRight;

    RaycastHit2D hit;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerTxt.text = timer.ToString("F2");
        
        Movement();
        Sprint();
    }

    void Movement()
    {
        inputs = Input.GetAxisRaw("Horizontal");
        if(kbCounter <= 0)
        {
            rb.velocity = new UnityEngine.Vector2(inputs * currentSpeed, rb.velocity.y);
        }
        else
        {
            if(KnockFromRight == true)
            {
                rb.velocity = new Vector2(-kbforce, kbforce);
            }
            if(KnockFromRight == false)
            {
                rb.velocity = new Vector2(kbforce, kbforce);
            }
            kbCounter -= Time.deltaTime;
        }

        hit = Physics2D.Raycast(transform.position, -transform.up, groundDistance, layerMask);
        Debug.DrawRay(transform.position, -transform.up * groundDistance, Color.yellow);

        if (hit.collider)
        {
            extraJump = extraJumpValue;
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
            
        }
        else if (!hit.collider && Input.GetButtonDown("Jump") && extraJump > 0)
            {
                Debug.Log("not grounded");
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                extraJump--;
            }
        
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            transform.position = startPos;
        }
        if (other.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.gameObject.CompareTag("OFB"))
        {
            transform.position = startPos;
        }
    }

    
}
