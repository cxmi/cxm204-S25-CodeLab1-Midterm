using UnityEngine;

public class WASDLilGuyControl : MonoBehaviour
{
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    private GameObject lilGuy;
    public Vector3 pos;
    public float speed = 1;
    public float rotationSpeed = 10f;  // Rotation speed
    public Rigidbody rb;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        lilGuy = gameObject;
        pos = lilGuy.transform.position;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = Vector3.zero;
        if (Input.GetKey(keyUp))
        {
            //pos.z = transform.position.z + speed * Time.deltaTime;
            movementDirection.z = 1f;
            rb.AddForce(Vector3.forward * speed);
            animator.SetBool("isWalking", true);

        }
        else if (Input.GetKeyUp(keyUp))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(keyDown))
        {
            //pos.z = transform.position.z - speed * Time.deltaTime;
            rb.AddForce(Vector3.back * speed);

            movementDirection.z = -1f; 
            animator.SetBool("isWalking", true);

        }
        else if (Input.GetKeyUp(keyDown))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(keyLeft))
        {
            //pos.x = transform.position.x - speed*Time.deltaTime;
            rb.AddForce(Vector3.left * speed);

            movementDirection.x = -1f;
            animator.SetBool("isWalking", true);

        }
        else if (Input.GetKeyUp(keyLeft))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(keyRight))
        {
            //pos.x = transform.position.x + speed *Time.deltaTime;
            rb.AddForce(Vector3.right * speed);

            movementDirection.x = 1f;
            animator.SetBool("isWalking", true);

        }
        else if (Input.GetKeyUp(keyRight))
        {
            animator.SetBool("isWalking", false);
        }
        
        // Normalize movement direction to avoid diagonal faster movement
        if (movementDirection.magnitude > 0)
        {
            movementDirection.Normalize();
        }
        
        //pos += movementDirection * speed * Time.deltaTime;
        
        //lilGuy.transform.position = pos;
        
        
        // Smooth rotation towards movement direction
        if (movementDirection != Vector3.zero)
        {
            // Calculate the target rotation based on movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            
            // Smoothly rotate towards the target rotation
            lilGuy.transform.rotation = Quaternion.Slerp(lilGuy.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

    }
}
