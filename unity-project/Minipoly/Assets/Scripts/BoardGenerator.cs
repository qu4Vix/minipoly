using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public static int size = 4;

    public GameObject[] map;
    public GameObject[] minigames = new GameObject[12];
    private GameObject[] selectedMinigames;
    private int[] luckBoxes;
    public GameObject luckSquare;
    public GameObject[] cornerBoxes = new GameObject[4];
    public GameObject boardBase;
    public Vector3[] corners;
    private Vector3[] constructionDirections = { Vector3.right, Vector3.back, Vector3.left, Vector3.forward };
    
    /* 
        "Hide and Seek", "Parkour", "King of the Kill",
        "Hot Potato", "The King", "Wild West",
        "Tile Painting", "Floor is lava", "Color Fight",
        "Knock them Out", "Tile Fall" , "TNT Run"
    */

    // Start is called before the first frame update
    void Start()
    {
        SetLenghts(size, 4);
        SelectLuck(1, size);
        SelectGames(size);
        SelectMap(size, 4);
        CreateMap(size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLenghts(int _size, int _luckBoxesNumber)
    {
        luckBoxes = new int[_luckBoxesNumber];
        map = new GameObject[4 * _size];
        selectedMinigames = new GameObject[(_size - 1) * 4];
    }

    void CreateMap(int _size)
    {
        for (int n = 0; n < 4; n++)
        {
            Instantiate(cornerBoxes[n], cornerBoxes[n].transform.position * (_size + 1), cornerBoxes[n].transform.rotation, transform);
        }
        for (int i = 0; i < 4; i++)
        {
            for (int n = _size*i; n < _size*(i + 1); n++)
            {
                Instantiate(map[n], corners[i] * (_size + 1) + constructionDirections[i] * 4 * (n + 1 - _size*i), map[n].transform.rotation, transform);
            }
        }
        GameObject board = Instantiate(boardBase, Vector3.zero, boardBase.transform.rotation, transform);
        board.transform.localScale = new Vector3(0.4f * _size, 1, 0.4f * _size);
    }

    void SelectMap(int _size, int _luckBoxesNumber)
    {
        int actualGame = 0;
        for (int i = 0; i < _luckBoxesNumber; i++)
        {
            map[luckBoxes[i]] = luckSquare;
        }
        for (int i = 0; i < _size * 4; i++)
        {
            if (map[i] != luckSquare)
            {
                map[i] = selectedMinigames[actualGame];
                actualGame++;
            }
        }
    }

    // Select the position of the luck boxes
    void SelectLuck(int _num, int _size)
    {
        for (int i = 0; i < _num * 4; i++)
        {
            luckBoxes[i] = Random.Range(i * _size, (i + 1) * _size);
        }
    }

    // Select the games that will be played
    public void SelectGames(int _size)
    {

        int arrayLength = minigames.Length;
        
        for (int i = 0; i < (_size-1)*4; i ++)
        {
            int minigameIndex = Random.Range(0, arrayLength);
            selectedMinigames[i] = minigames[minigameIndex];
            //print(minigames[minigameIndex]);
        }
    }

}
