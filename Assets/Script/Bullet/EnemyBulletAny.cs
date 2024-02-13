using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletAny : MonoBehaviour
{
    float dx;
    float dy;
    public void Setting(float angle, float speed)
    {
        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;
        if( transform.position.x < -6 || transform.position.x > 6 ||
            transform.position.y < -6 || transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
