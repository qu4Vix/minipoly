using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public static int size = 4;

    public string[] map = new string[4 * size];
    public string[] minigames = new string[12] { 
        "Hide and Seek", "Parkour", "King of the Kill",
        "Hot Potato", "The King", "Wild West",
        "Tile Painting", "Floor is lava", "Color Fight",
        "Knock them Out", "Tile Fall" , "TNT Run"};
    private string[] selectedMinigames = new string[3 * size];
    private int[] luckBoxes = new int[size];

    // Start is called before the first frame update
    void Start()
    {
        SelectLuck(1, size);
        SelectGames(selectedMinigames.Length);
        SelectMap(size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMap()
    {
        for (int n = 0; n < map.Length; n++)
        {

        }
    }

    void SelectMap(int _size)
    {
        int actualGame = 0;
        for (int i = 0; i < _size; i++)
        {
            map[luckBoxes[i]] = "Luck";
        }
        for (int i = 0; i < _size * _size; i++)
        {
            if (map[i] != "Luck")
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
