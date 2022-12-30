using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public static int size = 4;

    public GameObject[] map = new GameObject[4 * size];
    public GameObject[] minigames = new GameObject[12];
    private GameObject[] selectedMinigames = new GameObject[12];
    private int[] luckBoxes = new int[4];
    public GameObject luckSquare;
    public GameObject[] cornerBoxes = new GameObject[4];
    public Vector3[] corners;
    
    /* 
        "Hide and Seek", "Parkour", "King of the Kill",
        "Hot Potato", "The King", "Wild West",
        "Tile Painting", "Floor is lava", "Color Fight",
        "Knock them Out", "Tile Fall" , "TNT Run"
    */

    // Start is called before the first frame update
    void Start()
    {
        SelectLuck(1, size);
        SelectGames(12);
        SelectMap(size);
        CreateMap(size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMap(int _size)
    {
        for (int n = 0; n < 4; n++)
        {
            Instantiate(cornerBoxes[n], cornerBoxes[n].transform.position * (_size + 1), cornerBoxes[n].transform.rotation);
        }
        for (int n = 0; n < _size; n++)
        {
            Instantiate(map[n], corners[0] * (_size + 1) + Vector3.right * 4 * (n+1), map[n].transform.rotation);
        }
        for (int n = _size; n < _size*2; n++)
        {
            Instantiate(map[n], corners[1] * (_size + 1) + Vector3.back * 4 * (n - 3), map[n].transform.rotation);
        }
        for (int n = _size*2; n < _size*3; n++)
        {
            Instantiate(map[n], corners[2] * (_size + 1) + Vector3.left * 4 * (n - 7), map[n].transform.rotation);
        }
        for (int n = _size * 3; n < _size * 4; n++)
        {
            Instantiate(map[n], corners[3] * (_size + 1) + Vector3.forward * 4 * (n - 11), map[n].transform.rotation);
        }
    }

    void SelectMap(int _size)
    {
        int actualGame = 0;
        for (int i = 0; i < _size; i++)
        {
            map[luckBoxes[i]] = luckSquare;
        }
        for (int i = 0; i < _size * _size; i++)
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
        
        for (int i = 0; i < _size; i ++)
        {
            int minigameIndex = Random.Range(0, arrayLength);
            selectedMinigames[i] = minigames[minigameIndex];
            print(minigames[minigameIndex]);
            
        }
    }

}
