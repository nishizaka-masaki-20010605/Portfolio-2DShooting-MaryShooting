using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBullet : MonoBehaviour
{
    void Update()//画面外の弾丸を破壊
    {
        if( transform.position.x < GameData.instance.MinX-1 || transform.position.x > GameData.instance.MaxX+1 ||
            transform.position.y < GameData.instance.MinY-1.5 || transform.position.y > GameData.instance.MaxY)
        {
            Destroy(gameObject);
        }
    }
}