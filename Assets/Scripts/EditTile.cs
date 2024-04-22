using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EditTile : MonoBehaviour
{
    [SerializeField] bool isEditable;
    [SerializeField] GameObject tagObj;
    [SerializeField] SpriteRenderer spriteRenderer;

    TileManager tileManager;
    ReadFile readFile;

    private void Awake()
    {
        tileManager = FindObjectOfType<TileManager>();
        readFile = FindObjectOfType<ReadFile>();
    }

    private void OnMouseEnter()
    {
        //Debug.Log(gameObject);
        isEditable = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        color.a = 0.5f;
        spriteRenderer.color = color;
    }

    private void OnMouseExit()
    {
        isEditable = false;
        Color color = spriteRenderer.color;
        color.a = 1f;
        spriteRenderer.color = color;
    }

    void DeleteTile()
    {
        if (Input.GetKey(KeyCode.E) && isEditable)
        {
            Color color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;

            gameObject.SetActive(false);
            tileManager.tilesList.Add(gameObject);
            isEditable = false;

            int i = (int)(gameObject.transform.position.x + 0.1f);
            int j = (int)(gameObject.transform.position.y + 0.1f);

            readFile.tileGrid[i, j] = null;
        }
    }

    void ReplaceTiles()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isEditable)
        {
            if (gameObject.tag == "Wall")
            {
                Debug.Log(" Wall already");
            }
            else
            {
                GameObject wall = Instantiate(readFile.wall, gameObject.transform.position, Quaternion.identity);
                wall.transform.parent = readFile.parentGameobject.transform;
                Destroy(gameObject);

                int i = (int)(wall.transform.position.x + 0.1f);
                int j = (int)(wall.transform.position.y + 0.1f);

                readFile.tileGrid[i, j] = wall;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && isEditable)
        {
            if (gameObject.tag == "Box")
            {
                Debug.Log(" Box already");
            }

            else
            {
                GameObject box = Instantiate(readFile.box, gameObject.transform.position, Quaternion.identity);
                box.transform.parent = readFile.parentGameobject.transform;
                Destroy(gameObject);

                int i = (int)(box.transform.position.x + 0.1f);
                int j = (int)(box.transform.position.y + 0.1f);

                readFile.tileGrid[i, j] = box;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && isEditable)
        {
            if (gameObject.tag == "Ground")
            {
                Debug.Log(" Ground already");
            }

            else
            {
                GameObject ground = Instantiate(readFile.ground, gameObject.transform.position, Quaternion.identity);
                ground.transform.parent = readFile.parentGameobject.transform;
                Destroy(gameObject);

                int i = (int)(ground.transform.position.x + 0.1f);
                int j = (int)(ground.transform.position.y + 0.1f);

                readFile.tileGrid[i, j] = ground;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4) && isEditable)
        {
            if (gameObject.tag == "Player")
            {
                Debug.Log(" Player already");
            }

            else
            {
                GameObject player = Instantiate(readFile.player, gameObject.transform.position, Quaternion.identity);
                player.transform.parent = readFile.parentGameobject.transform;
                Destroy(gameObject);

                int i = (int)(player.transform.position.x + 0.1f);
                int j = (int)(player.transform.position.y + 0.1f);

                readFile.tileGrid[i, j] = player;
            }   
        }

        else if (Input.GetKeyDown(KeyCode.Alpha5) && isEditable)
        {
            if (gameObject.tag == "Goal")
            {
                Debug.Log(" Goal already");
            }

            else
            {
                GameObject goal = Instantiate(readFile.goal, gameObject.transform.position, Quaternion.identity);
                goal.transform.parent = readFile.parentGameobject.transform;
                Destroy(gameObject);

                int i = (int)(goal.transform.position.x + 0.1f);
                int j = (int)(goal.transform.position.y + 0.1f);

                readFile.tileGrid[i, j] = goal;
            }
        }
    }

    private void Update()
    {
        DeleteTile();
        ReplaceTiles();
    }
}
