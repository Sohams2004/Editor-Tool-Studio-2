using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Linq;
using System.Text;

public class ReadFile : MonoBehaviour
{
    public GameObject[,] tileGrid;

    [SerializeField] public GameObject wall, ground, goal, player, box;
    [SerializeField] public GameObject parentGameobject;
    [SerializeField] public int fileIndex;
    [SerializeField] bool isLevel;

    int height;
    int width;


    private void Start()
    {
        Read();
    }

    public void GenerateLevels()
    {
        foreach(Transform children in parentGameobject.transform)
        {
            Destroy(children.gameObject);
        }
    }

    public void Read()
    {
        fileIndex = Random.Range(1, 50);

        var file = File.ReadLines($"{Application.streamingAssetsPath}/{fileIndex}.txt").ToArray();

        height = file[1].Length;
        width = file[0].Length;

        tileGrid = new GameObject[height, width];

        for (int i = 0; i < file.Length; i++)
        {
            string line = file[i];

            for (int j = 0; j < line.Length; j++)
            {
                char character = line[j];
                Vector2 position = new Vector2(i, j);

                if (character == '@')
                {
                    //Debug.Log(line[j]);
                    tileGrid[i, j] = Instantiate(wall, position, Quaternion.identity);
                    tileGrid[i, j].transform.parent = parentGameobject.transform;
                }

                if (character == ' ')
                {
                    tileGrid[i, j] = Instantiate(ground, position, Quaternion.identity);
                    tileGrid[i, j].transform.parent = parentGameobject.transform;
                }

                if (character == 'x')
                {
                    tileGrid[i, j] = Instantiate(goal, position, Quaternion.identity);
                    tileGrid[i, j].transform.parent = parentGameobject.transform;                    
                }

                if (character == 'o')
                {
                    tileGrid[i, j] = Instantiate(box, position, Quaternion.identity);
                    tileGrid[i, j].transform.parent = parentGameobject.transform;             
                }

                if (character == '<' || character == '>' || character == '^' || character == 'v')
                {
                    tileGrid[i, j] = Instantiate(player, position, Quaternion.identity);
                    tileGrid[i, j].transform.parent = parentGameobject.transform;                 
                }
            }
        }
    }

    char TileChar(GameObject tile)
    {
        if (tile == null)
        {
            return ' ';
        }

        if (tile.CompareTag("Wall"))
        {
            return '@';
        }

        else if (tile.CompareTag("Ground"))
        {
            return ' ';
        }

        else if (tile.CompareTag("Goal"))
        {
            return 'x';
        }

        else if (tile.CompareTag("Box"))
        {
            return 'o';
        }

        else if (tile.CompareTag("Player"))
        {
            return 'v';
        }

        else
        {
            return ' ';
        }
    }

    public string LevelData()
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject tile = tileGrid[i, j];
                char tileChar = TileChar(tile);
                stringBuilder.Append(tileChar);
            }
            stringBuilder.Append("\n");
        }

        return stringBuilder.ToString();
    }
}
