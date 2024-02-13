using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void Update()
    {
        transform.position +=  new Vector3(0,20f,0)*Time.deltaTime;
        Invoke("Destroy", 3);
        //三秒後に破壊する関数を呼び出す
    }

    //三秒後に破壊する関数
    void Destroy(){
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyBase enemy))
        {
            enemy.TakeDamage(1);

            // ミサイルを破壊する。
            Destroy(gameObject);
        }
    }
    
}
