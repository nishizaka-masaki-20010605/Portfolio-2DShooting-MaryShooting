using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.position +=  new Vector3(0,GameData.instance.Player_bullet_speed,0)*Time.deltaTime;
        if( transform.position.x < GameData.instance.MinX-1 || transform.position.x > GameData.instance.MaxX+1 ||
            transform.position.y < GameData.instance.MinY-1.5 || transform.position.y > GameData.instance.MaxY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyBase enemy))
        {
            enemy.TakeDamage(GameData.instance.Enemy_damege);//敵に１のダメージを与える

            // ミサイルを破壊する。
            Destroy(gameObject);
        }
    }
    
}
