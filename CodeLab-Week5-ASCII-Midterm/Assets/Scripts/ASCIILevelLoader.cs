using System.IO;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    //give this a file to load

    private string filePath;
    public string fileName; // set this in the inspector
    private int currentLevel = 0;

    public int CurrentLevel
    {
        set
        {
            currentLevel = value;
            LoadLevel();
            // every time Current Level changes, ie every time the value gets set, then it Loads Level()
        }
        get
        {
            return currentLevel;
        }
    }

    public float offsetX = -3;
    public float offsetY = -3;
    
    public GameObject prefabPlayer;
    public GameObject prefabWall;
    public GameObject prefabObstacle;
    public GameObject prefabGoal;

    private GameObject levelHolder;
    void Awake()
    {
        //LoadLevel();
        CurrentLevel = 0;
    }   
    public void LoadLevel()
    {
        if (levelHolder != null)
        {
            Destroy(levelHolder);
        }
        
        levelHolder = new GameObject("Level Holder"); // creates a new empty gameobject named Level Holder

        
        filePath = Application.dataPath;
        //file is the class we are using to grab things
        //string fileContents = File.ReadAllText(filePath + fileName);
        //Debug.Log(fileContents);
        
        //if we instead wanted to read each line as its own string
        
        string[] lines = File.ReadAllLines(
            filePath + fileName.Replace("<num>", currentLevel + "")); // reads all lines into an array of strings
        //each slot is a line in the file
        //currentLevel + "" is also currentLevel.ToString()

        //looping through each line of the file
        for (int y = 0; y < lines.Length; y++)
        {
            Debug.Log(lines[y]);

            string line      = lines[y]; // getting the string for this line
            char[] charArray = line.ToCharArray(); // turn that string into an array of characters
            
            //loop through each character on this line
            for (int x = 0; x < charArray.Length; x++)
            {
                char c = charArray[x];

                GameObject newObj = null;

                switch (c)
                {
                    case 'P':
                            newObj = Instantiate<GameObject>(prefabPlayer);
                        break;
                    case 'W':
                            newObj = Instantiate<GameObject>(prefabWall);
                        break;
                    case '*':
                        newObj = Instantiate<GameObject>(prefabObstacle);
                        break;
                    case 'G':
                        newObj = Instantiate<GameObject>(prefabGoal);
                        break;
                    default:
                        break;
                        
                }

                if (newObj != null)
                {
                    newObj.transform.parent = levelHolder.transform;
                    newObj.transform.position = 
                        new Vector3(x + offsetX, -y + offsetY, 0);
                }
                
                
                // if (c == 'P')
                // {
                //     newObj = Instantiate<GameObject>(prefabPlayer);
                //     newObj.transform.position = 
                //         new Vector3(x + offsetX, -y + offsetY, 0);
                // }
                //
                // if (c == 'W')
                // {
                //     newObj = Instantiate<GameObject>(prefabWall);
                //     newObj.transform.position =
                //         new Vector3(x + offsetX, -y + offsetY, 0);
                // }
            }
            
            // if (lines[y].Equals("P"))
            // {
            //     Instantiate<GameObject>(prefabPlayer);
            // }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
