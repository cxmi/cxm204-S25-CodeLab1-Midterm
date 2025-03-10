using UnityEngine;

public class WASDPlyaerControl : MonoBehaviour
{
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    private Rigidbody rb;
    public float speed = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyUp))
        {
            rb.AddForce(Vector3.up * speed);
        }

        if (Input.GetKeyDown(keyDown))
        {
            rb.AddForce(Vector3.down * speed);
        }

        if (Input.GetKeyDown(keyLeft))
        {
            rb.AddForce(Vector3.left * speed);
        }

        if (Input.GetKeyDown(keyRight))
        {
            rb.AddForce(Vector3.right * speed);
        }
    }
}
