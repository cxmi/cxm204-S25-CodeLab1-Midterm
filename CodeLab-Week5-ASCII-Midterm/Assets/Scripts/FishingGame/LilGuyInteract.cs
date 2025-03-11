using UnityEngine;

public class LilGuyInteract : MonoBehaviour
{
    public KeyCode keyInteract;
    private Animator animator;
    
    
    //property for catching a fish

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyInteract))
        {
            animator.SetTrigger("interactTrigger");
            GameManagerScript.instance.FishCaught++;
            Debug.Log(GameManagerScript.instance.FishCaught);

        }

    }
    
    
}
