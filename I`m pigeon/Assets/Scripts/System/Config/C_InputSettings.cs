/// <summary>
/// C_InputSettings.cs
/// 输入键位控制
/// 考虑拿去转成json来保存设置
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class C_InputSettings : Component
{
    public string fwd = "w";
    public string bwd = "s";
    public string right = "d";
    public string left = "a";
    public string jump = "space";
    public string sprint = "left shift";
    public string courch = "left control";
    public string mouse_x = "Mouse X";
    public string mouse_y = "Mouse Y";
    public string fire = "mouse 0";
    public string aim = "mouse 1";
    public string reload = "r";
    public string pickPrimaryWeapon = "1";
    public string pickSecondaryWeapon = "2";
    public string combat = "v";
    public string scorePanel = "tab";
}
