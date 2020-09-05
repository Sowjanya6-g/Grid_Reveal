using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    int result;
    int length;
    int temp;
    int count;
    public List<int> compare = new List<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        length = 4;
        List<int> compare = new List<int>(length);
        
    }

    private void OnMouseDown()
    {
        Selection();
       
    }

    private void OnCollisionStay2D(Collision2D collision) // input through the keyboard
    {
        if(collision.gameObject.tag=="Hand")
        {
            if (Input.GetButtonDown("Jump"))
            {
                Selection();
            }
        }
    }

    public void Selection()
    {
        count = 0;
        GridManager.limit++;
        if (GridManager.limit <= 20 && GridManager.score < 10)
        {
            result = int.Parse(gameObject.name);
            temp = result;

            if ((temp + 3) > 0)  // storing the tiles that are two tiles away from the current tile
                compare[0] = temp + 3;
            else
                compare[0] = 0;

            if ((temp - 3) > 0)
                compare[1] = temp - 3;
            else
                compare[1] = 0;

            if ((temp + (GridManager.instance.columns * 3)) > 0)
                compare[2] = temp + (GridManager.instance.columns * 3);
            else
                compare[2] = 0;

            if ((temp - (GridManager.instance.columns * 3)) > 0)
                compare[3] = temp - (GridManager.instance.columns * 3);
            else
                compare[3] = 0;

            for (int i = 0; i < 4; i++)
            {
                if (GridManager.instance.rand.Contains(compare[i])) // checking if the item tile is two tiles from this tile
                {
                    count++;
                }
            }
            if (GridManager.instance.rand.Contains(result)) //checking if the item tile is clicked
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                GridManager.score++;
            }
            else if (count > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                count = 0;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
    
}
