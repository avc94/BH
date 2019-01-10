using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public Transform groundCheck;
    public LayerMask whatIsGround;
    Vector3 offset = new Vector3(0f, 0.25f, 0f);
    bool grounded = false;
    //float groundRadius = 0.2f;
    float maxSpeed = 10f;
    float jumpForce = 700f;
    float movingAxis;

    PlayerInventory inventory;

    [SyncVar(hook = "FacingCallback")]
    bool facingRight = true;

    public override void OnStartLocalPlayer()
    {
        // set this player object as target for a camera
        Camera.main.GetComponent<CameraController>().SetTarget(gameObject);
    }

    private void Awake()
    {
        inventory = GetComponent<PlayerInventory>();
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer || inventory.BadgesOnLevelRemaining < 1) return;
        grounded = Physics2D.OverlapPoint(groundCheck.position - offset, whatIsGround);
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        movingAxis = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        if (!isLocalPlayer || inventory.BadgesOnLevelRemaining < 1) return;

        //moving
        if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(movingAxis * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //flipping
        if ((movingAxis > 0 && !facingRight) || (movingAxis < 0 && facingRight))
        {
            facingRight = !facingRight;
            CmdFlipSprite(facingRight);
        }
    }

    [Command]
    void CmdFlipSprite(bool facing)
    {
        FacingCallback(facing);
    }

    void FacingCallback(bool facing)
    {
        facingRight = facing;
        Vector3 SpriteScale = transform.localScale;
        SpriteScale.x = facingRight ? 1 : -1;
        transform.localScale = SpriteScale;
    }
}
