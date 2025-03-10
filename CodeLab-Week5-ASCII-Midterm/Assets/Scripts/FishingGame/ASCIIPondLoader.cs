using UnityEngine;
using System.IO;

public class ASCIIPondLoader : MonoBehaviour
{
    public GameObject prefabWater;
    public GameObject prefabSpecialWater;
    private int currentPond = 0;
    private GameObject pondHolder;
    private string filePath;
    public string fileName;
    public float offsetX = 3;
    public float offsetZ = 3;

    public int CurrentPond
    {
        set
        {
            currentPond = value;
            LoadPond();
            // every time Current Level changes, ie every time the value gets set, then it Loads Level()
        }
        get
        {
            return currentPond;
        }
    }

    public void Awake()
    {
        CurrentPond = 0;
    }
    public void LoadPond()
    {
        if (pondHolder != null)
        {
            Destroy(pondHolder);
        }

        pondHolder = new GameObject("Pond Holder"); // creates a new empty gameobject named Level Holder

        filePath = Application.dataPath;
        string[] lines = File.ReadAllLines(
            filePath + fileName.Replace("<num>", currentPond + ""));

        for (int z = 0; z < lines.Length; z++)
        {
            Debug.Log(lines[z]);

            string line = lines[z]; // getting the string for this line
            char[] charArray = line.ToCharArray(); // turn that string into an array of characters

            //loop through each character on this line
            for (int x = 0; x < charArray.Length; x++)
            {
                char c = charArray[x];

                GameObject newObj = null;

                switch (c)
                {
                    case 'W':
                        newObj = Instantiate<GameObject>(prefabWater);
                        break;
                    case 'S':
                        newObj = Instantiate<GameObject>(prefabSpecialWater);
                        break;
                    default:
                        break;
                }
                if (newObj != null)
                {
                    newObj.transform.parent = pondHolder.transform;
                    newObj.transform.position = 
                        new Vector3(x + offsetX, 0, z + offsetZ);
                }
            }

        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
