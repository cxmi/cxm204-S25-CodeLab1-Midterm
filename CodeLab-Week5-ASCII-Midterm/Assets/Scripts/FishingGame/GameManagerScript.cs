using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private int fishCaught = 0;
    public static GameManagerScript instance;
    public TextMeshProUGUI fishScore;

    public int FishCaught
    {
        get
        {
            return fishCaught;
        }
        set
        {
            fishCaught = value;
            fishScore.text = "Fish: " + fishCaught.ToString();
            
        }
    }
    
    
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // better than DontDestroyOnLoad(this) according to Matt
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
