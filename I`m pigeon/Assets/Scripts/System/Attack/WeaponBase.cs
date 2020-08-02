/// <summary>
/// WeaponBase.cs
/// 所有武器类型的基类
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBase : MonoBehaviour
{
    //定义开火模式
    public enum FireMode
    {
        Safe = 0,
        Single,
        Burst,
        Auto
    }

    //定义武器类型
    public enum WeaponType
    {
        Melee = 0,      //近战武器
        Pistol,         //手枪(单发短武器)
        SMG,            //冲锋枪(连发短武器)
        Shotgun,        //霰弹枪(多弹丸武器)
        AssaultRifle,   //突击步枪(连发长武器)
        Rifle,          //步枪(单发长武器)
        Spell,          //法术
        Special         //特殊
    }

    //在玩家身上的攻击控制器
    public AttackController controller;

    //武器类型
    private WeaponType _type;   
    public WeaponType Type => _type;

    //开火模式
    private FireMode _mode;     
    public FireMode Mode => _mode;

    //最大弹容量
    private int _maxAmmo;

    //当前载弹量
    private int _currentAmmo;
    public int CurrentAmmo
    {
        get { return _currentAmmo; }
        set
        {
            if (value > _maxAmmo)
                _currentAmmo = _maxAmmo;
        }
    }

    //攻击间隔(开火速率)
    private float _fireRate;
    public float FireRate => _fireRate;

    //重装冷却(为0则不可冷却)
    private float _reloadCoolDown;
    public float ReloadCD => _reloadCoolDown;

    //武器精准度(部分武器没有这个东西)
    //这玩意就是正态分布的标准差
    private float _sigma;   
    public float Accuracy => _sigma;

    //射出点(部分武器没有这个东西)
    public Transform ShootPoint;

    //攻击的方法(子类重写)
    public void Attack()
    {
        Debug.LogError("Default Attact Funtion Called!");
    }




}
