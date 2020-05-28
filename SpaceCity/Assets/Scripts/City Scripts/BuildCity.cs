using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public int mapWidth = 20;
    public int mapHeight = 20;
    int buildingFootprint = 60;


    void Start()
    {
       
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {


                Vector3 pos = new Vector3(w * buildingFootprint, .1f, h * buildingFootprint);

                int n = Random.Range(0, buildings.Length);
                Instantiate(buildings[n], pos, Quaternion.identity);

            }
        }
    }




    

}
/*
/*int n = Random.Range(0, buildings.Length);
Instantiate(buildings[n], pos, Quaternion.identity);
                 
                if (result< 2)
                {
                    Instantiate(buildings[0], pos, Quaternion.identity);
                }
                else if (result< 4)
                {
                    Instantiate(buildings[1], pos, Quaternion.identity);
                }
*/
