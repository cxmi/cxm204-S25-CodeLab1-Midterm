using UnityEngine;

public class GoalScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<ASCIILevelLoader>().CurrentLevel++;
    }
    
    
    
}
