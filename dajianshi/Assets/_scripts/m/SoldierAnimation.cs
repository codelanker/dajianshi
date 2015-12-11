using UnityEngine;
using System.Collections;

public class SoldierAnimation
{
    public const int 站立 = 0;
    public const int 前走 = 1;
    public const int 后退 = 2;
    public const int 左移 = 3;
    public const int 右移 = 4;
    public const int 跳起 = 5;
    public const int 下落 = 6;
    public const int 开火 = 7;
    public static string name(int id)
    {
        string name = "";
        switch (id)
        {
            case 站立: name = "Idle_"; break;
            case 前走: name = "Run_"; break;
            case 后退: name = "Run_Backward_"; break;
            case 左移: name = "Run_Left_"; break;
            case 右移: name = "Run_Right_"; break;
            case 跳起: name = "Jump_"; break;
            case 下落: name = "Fall_"; break;
            case 开火: name = "Fire_"; break;
            default: break;
        }
        return name;
    }
}
