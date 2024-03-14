using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public float MinX;//-5.5
    public float MaxX;//5.5
    public float MinY;//-4.5
    public float MaxY;//6

    public float Player_bullet_speed;//20f
    public float Aim_speed;//30f
    public int Enemy_damege;//1
    public float Enemy_bullet_speed;//200.0f

    public int Enemy_HP_base;//100
    public int Enemy_Boss_multiplication;//3
    public int stage_boss_two;//2
    public int stage_boss_three;//3
    public int stage_boss_four;//4
    public int stage_boss_five;//5
    public int stage_boss_six;//6
    public int stage_boss_seven;//7


    public float Enemy_position;//3f

        public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
