using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContol : MonoBehaviour
{

    Rigidbody2D playerBody;
    BoxCollider2D boxCollider;

    float horizontalMoveForce;
    public float horizontalMoveAccleration;
    public float maxHorizontalMoveSpeed;
    public float jumpPower;
    public float maxJumps;
    public float jumps;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public float groundDistance = 0.05f;
    public LayerMask groundLayer;
    public bool isGrounded;

    public Vector2 currentSpawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        Move();
        
        

        
    }

    public void OnMove(InputValue value)
    {
        horizontalMoveForce = value.Get<Vector2>().x;
        
    }

    public void OnJump(InputValue value)
    {
        
        if (jumps > 0)
        {
            playerBody.linearVelocityY = jumpPower;
            jumps--;
        }
        
        
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.CircleCast(groundCheck.position, groundRadius, Vector2.down, groundDistance, groundLayer);

        if (isGrounded)
        {
            ResetJumps();
        }
    }

    void Move()
    {
        if (playerBody.linearVelocityX < maxHorizontalMoveSpeed && playerBody.linearVelocityX > -maxHorizontalMoveSpeed)
        {
            playerBody.AddForceX(horizontalMoveForce * horizontalMoveAccleration * Time.deltaTime);
        }
    }

    public void ResetJumps()
    {
        jumps = maxJumps;
    }

    public void AddJumps(int addedJumps)
    {
        jumps += addedJumps;
    }

    public void SetSpawnPoint(GameObject spawnPoint)
    {
        currentSpawnPoint = spawnPoint.transform.position;
    }

    public void Die()
    {
        playerBody.position = currentSpawnPoint;
        playerBody.rotation = 0;
        playerBody.angularVelocity = 0;
        playerBody.linearVelocity = Vector2.zero;
    }

    


}
