using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Platform : MonoBehaviour
{
    public Tilemap platformTilemap;

    public int width;

    public int height;

    public TileBase platformTile;

    public bool ispass =false;

    public int contx;

    private BoxCollider2D coll;

    public int score=0;

    private void Start()
    {
        coll= GetComponent<BoxCollider2D>();
        CleanTileMap();
        GenerateTileMap(0,0);
    }
    

    //绘制地图
    public void GenerateTileMap(int rx,int ry)
    {
        for (int x=rx;x<width+rx;x++)
        {
            for(int y=ry;y<height+ry;y++)
            {
                platformTilemap.SetTile(new Vector3Int(x+contx,y), platformTile);
            }
        }

        contx += rx + width;
        
    }

    //生成新平台
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Cat")
        {
            ispass = true;

            int rx = RandomRx();
            int ry = RandomRy();
            GenerateTileMap(rx,ry);

            coll.offset= new Vector3(contx-width,coll.offset.y);

            score++;
        }
    }

    //触发器初始化
    public void ColliderAgain()
    {
        coll.offset = new Vector3(1.5f, coll.offset.y);
    }

    //平台空空隙
    public int RandomRx()
    {
        int rx=(int)Random.Range(2,3);

        return rx;
    }

    //上下偏移
    public int RandomRy()
    {
        int ry = (int)Random.Range(-2, 2);
        return ry;
    }

    //清空平台
    public void CleanTileMap()
    {
        platformTilemap.ClearAllTiles();
    }
}
