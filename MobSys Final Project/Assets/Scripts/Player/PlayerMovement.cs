using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    [Header("Audio")]
    [SerializeField] private AudioClip[] audioClips;

    private Vector2 movement;
    
    private static PlayerMovement instance;
    

    void Awake()
    {
        instance = this;

        Vector2 position = Database.GetPlayerPosition(transform.position);
        Vector3 newPosition = new Vector3(position.x, position.y, transform.position.z);

        transform.position = newPosition;
    }

    void Update()
    {
        // Keyboard Controls
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // If no keyboard input, set values from joystick instead
        if (movement.x == 0) movement.x = joystick.Direction.x;
        if (movement.y == 0) movement.y = joystick.Direction.y;

        // Flip the sprite depending if the x movement is negative or not
        if (movement.x != 0) spriteRenderer.flipX = movement.x < 0;
    }

    void FixedUpdate()
    {
        rigidbody2d.MovePosition(rigidbody2d.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);

        bool isRunning = movement.x != 0 || movement.y != 0;
        animator.SetBool("IsRunning", isRunning);
    }

    public void PlayFootstep()
    {
        int randomIndex = Random.Range(0, audioClips.Length -1);
        AudioClip audioClip = audioClips[randomIndex];
        AudioPlayer.PlayAudioClip(audioClip);
    }

    public static void SavePosition()
    {
        Vector3 position = instance.transform.position;
        Database.SetPlayerLocation(position);
    }
}