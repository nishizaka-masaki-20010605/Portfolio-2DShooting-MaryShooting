using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public int HP;

    public virtual void TakeDamage(int PlayerBulletPower)
    {
        HP -= PlayerBulletPower;
    }
    
}
