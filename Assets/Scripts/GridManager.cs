using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    [SerializeField]
    public int rows = 20;
    [SerializeField]
    public int columns = 20;
    [SerializeField]
    private float tileSize = 1f;
    [SerializeField]
    private int output = 10;

    public static int limit;
    public static int score;
    public static int highScore;

    private List<GameObject> list = new List<GameObject>();
    public List<int> rand = new List<int>();

    int total;
    int count;
    public GameObject text;
    public GameObject scoreText;
    public GameObject highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
        limit = 0;
        score = 0;
        count = 0;
        total = rows * columns;

        highScore = PlayerPrefs.GetInt("highScore", highScore);
        highScoreText.GetComponent<Text>().text = highScore.ToString();
        
        List<GameObject> list = new List<GameObject>(total);
        List<int> Rand = new List<int>(output);
        GenerateTiles();
        PickupTiles();

    }

    private void GenerateTiles() //Generates a dynamic grid of required size
    {
        GameObject tile = (GameObject)Instantiate(Resources.Load("Tile"));
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                GameObject grid = (GameObject)Instantiate(tile, transform);
                count++;
                grid.name = count.ToString();
                float posX = tileSize * column;
                float posY = -tileSize * row;
                grid.transform.position = new Vector2(posX, posY);
                list.Add(grid);
            }

        }
        Destroy(tile);
        float gridW = columns * tileSize;
        float gridH = rows * tileSize;
        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2); //centres the grid on the screen

    }

    private void PickupTiles() //randomly picks up 10 item tiles with out repition
    {
        for(int i=0;i<output; i++)
        {
            int num = Random.Range(1, total);
            while(rand.Contains(num))
            {
                num = Random.Range(1, total);
            }
            rand.Add(num);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = score.ToString();
        if (limit>20)
        {
            text.SetActive(true);
        }
        if(score==10)
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "Well Done!";
        }
        if(score>highScore)
        {
            highScore = score;
            highScoreText.GetComponent<Text>().text = highScore.ToString(); 
            PlayerPrefs.SetInt("highScore", highScore); //highscore is stored 
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Grid_Reveal"); // restarts the game
    }
}

