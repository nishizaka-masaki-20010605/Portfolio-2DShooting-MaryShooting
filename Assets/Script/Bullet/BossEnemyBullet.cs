using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBullet : MonoBehaviour
{
    void Update()//画面外の弾丸を破壊
    {
        if( transform.position.x < -6 || transform.position.x > 6 ||
            transform.position.y < -6 || transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
