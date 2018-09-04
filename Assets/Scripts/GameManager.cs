using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //GameObject Player;
    //Vector3 position;
    //bool playerMovingFlag;
    //public PlayerController playerScriput;
    public GameObject canvasGame;//ゲームキャンバス
    public GameObject mapTile00;
    public GameObject mapTile01;

    public Layer2D MapData = null;

    //int[,] mapCollisionData;
    int[,] mapData ={
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,}
        };

    // Use this for initialization
    void Start()
    {
        MapData = ConvertTo2DLayer(mapData);
        CreateMap();
        //Player = GameObject.Find("Player(KARI)");
        //playerScriput = GameObject.Find("Player(KARI)").GetComponent<PlayerController>();
        //ConvertMapCollisionData(mapData);

    }

    // Update is called once per frame
    void Update()
    {
        //position = this.Player.transform.position;
        //playerMovingFlag = this.playerScriput.GetMovingFlag();
        //if (playerMovingFlag == true)
        //{
        //    Debug.Log(position.x + " : " + position.y);
        //}

    }

    //public int[,] GetMap()
    //{
    //    return mapCollisionData;
    //}

    //マップデータを元にマップタイルを配置する。
    void CreateMap()
    {
        //int y = mapData.GetLength(0);
        //int x = mapData.GetLength(1);
        GameObject instanceObject;
        Vector3 position;

        MapData.Dump();
        for (int i = 0; i < MapData.Height; i++)
        {
            for (int j = 0; j < MapData.Width; j++)
            {
                if (MapData.Get(j,i) == 1)
                {
                    position = new Vector3(((float)j*50 - 400), ((float)i*50 - 225) * -1, 0);

                    instanceObject = (GameObject)Instantiate(mapTile00);
                    instanceObject.transform.SetParent(canvasGame.transform, false);
                    instanceObject.transform.localPosition = position;
                    instanceObject.name = "" + mapTile00.name + "(" + i + "," + j + ")";
                    
                }
                //else if (mapData[i, j] == 2)
                //{
                //    position = new Vector3(((float)j - 9), ((float)i - 5) * -1, 0);
                //    instanceObject = Instantiate(mapTile01) as GameObject;
                //    instanceObject.transform.position = position;
                //    instanceObject.name = "" + mapTile01.name + "(" + i + "," + j + ")";
            }
        }
    }

    ////マップデータを元に衝突判定データを作成する。
    //void ConvertMapCollisionData(int[,] mapData)
    //{
    //    int y = mapData.GetLength(0);
    //    int x = mapData.GetLength(1);
    //    int k;
    //    mapCollisionData = new int[y, x];
    //    for (int i = 0; i < y; i++)
    //    {
    //        for (int j = 0; j < x; j++)
    //        {
    //            k = (y - i) - 1;
    //            if (mapData[k, j] == 1)
    //            {
    //                mapCollisionData[i, j] = 1;
    //            }
    //            else if (mapData[k, j] == 2)
    //            {
    //                mapCollisionData[i, j] = 1;
    //            }
    //        }
    //    }
    //}

    //Layer2Dでマップを管理する。（テスト）
    Layer2D ConvertTo2DLayer(int[,] mapData)
    {
        Layer2D _layer = null;
        int h = mapData.GetLength(0);
        int w = mapData.GetLength(1);
        int k;

        _layer = new Layer2D();
        _layer.Create(w, h);

        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                k = (h - i) - 1;
                _layer.Set(j, i, mapData[i, j]);
            }
        }

        return _layer;
    }
}
