using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> tilesList;

    ReadFile readFile;

    private void Start()
    {
        readFile = FindObjectOfType<ReadFile>();
    }

    void RestoreTile()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (tilesList is not null && tilesList.Count > 0)
            {
                try
                {
                    GameObject lastTile;

                    if (tilesList.Count is not 0)
                    {
                        lastTile = tilesList[tilesList.Count - 1];
                    }
                    else
                    {
                        lastTile = tilesList[tilesList.Count];
                    }

                    Debug.Log(lastTile);
                    lastTile.SetActive(true);
                    tilesList.Remove(lastTile);

                    int i = (int)(lastTile.transform.position.x + 0.1f);
                    int j = (int)(lastTile.transform.position.y + 0.1f);

                    readFile.tileGrid[i, j] = lastTile;
                }

                catch(System.Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
    }

    private void Update()
    {
        RestoreTile();
    }
}
