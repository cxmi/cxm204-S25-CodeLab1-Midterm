using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class LilGuyInteract : MonoBehaviour
{
    public KeyCode keyInteract;
    private Animator animator;

    [SerializeField] bool touchingSpecial = false;
    [SerializeField] bool touchingWater = false;
    public TextMeshProUGUI displayText;
    
    
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
            //GameManagerScript.instance.FishCaught++;
            Debug.Log(GameManagerScript.instance.FishCaught);
            //displayText.text = "Hello!";
            
            if (touchingWater)
            {
                int chance = Random.Range(0, 4);

                switch (chance)
                {
                    case 0:
                        displayText.text = "You caught a goldfish!";
                        GameManagerScript.instance.FishCaught++;
                        break; 
                    case 1:
                        displayText.text = "You caught a minnow!";
                        GameManagerScript.instance.FishCaught++;
                        break;
                    case 2:
                        displayText.text = "You caught nothing :(";
                        break;
                    case 3:
                        displayText.text = "You caught nothing :(";
                        break;
                    default:
                        break;
                }
            }

            if (touchingSpecial)
            {
                int chance = Random.Range(0, 4);

                switch (chance)
                {
                    case 0:
                        displayText.text = "You caught a SHARK!";
                        GameManagerScript.instance.FishCaught++;
                        break; 
                    case 1:
                        displayText.text = "You caught nothing :(";
                        break;
                    case 2:
                        displayText.text = "You caught nothing :(";
                        break;
                    case 3:
                        displayText.text = "You caught a piece of trash :(";
                        break;
                    default:
                        break;
                }
            }

        }

    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Normal")){
            //Debug.Log(other.gameObject.name);
            touchingWater = true;
            touchingSpecial = false;

        }
        
        if (other.gameObject.CompareTag("Special")){
            //Debug.Log(other.gameObject.name);
            touchingSpecial = true;
            touchingWater = false;

        }

      
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Normal")){
            touchingWater = false;
        }
        if (other.gameObject.CompareTag("Special")){
            //Debug.Log(other.gameObject.name);
            touchingSpecial = false;
        }
    }
    
}
