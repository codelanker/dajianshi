using UnityEngine;
using System.Collections;

public class SoldierController : MonoBehaviour
{
    public Soldier soldier;
    public float speedRun = 0;
    public float speedJump = 0;
    public float speedRotateCameraY = 0;
    public float speedRotateCameraX = 0;
    public float speedRotateStar = 0;
    public Vector2 rangeRotateCameraX = new Vector2(0.0f,30.0f);
    public Color colorStarDefault;
    public Color colorStarAimed;

    public float fireEffectDelayTime = 1f;
    private float fireEffectDelayTimeCount = 0.0f;
    private bool isAllowfireEffect = false;

    public void Start()
    {
        SoldierStar.scale(soldier.star);
    }

    public void Update()
    {
        _star();
    }

    public void go(float v, float h, bool tab, bool space, bool q, bool e, bool c, bool z,bool fire)
    {
        _animation(v, h, tab, space,fire);
        _effect();
        _camera(q, e, c, z);
    }
    private void _star()
    {
        SoldierStar.rotate(soldier.star, speedRotateStar);
        SoldierStar.changeColre(soldier.star, soldier._camera, colorStarDefault, colorStarAimed);
    }
    private void _camera(bool q, bool e, bool c, bool z)
    {
        int rotateDirect = q ? (e ? 0 : -1) : (e ? 1 : 0);
        int rotateDirectX = c ? (z ? 0 : -1) : (z ? 1 : 0);
        if (rotateDirect != 0)
        {
            soldier.rotate(rotateDirect, speedRotateCameraY);
        }
       //Debug.Log("rotateDirectX=" + rotateDirectX);
        if (rotateDirectX != 0)
        {
            SoldierCamera.rotateX(rotateDirectX, speedRotateCameraX, soldier._camera, rangeRotateCameraX);
        }
    }
    private void _animation(float v, float h, bool tab, bool space,bool fire)
    {
        if (tab)
        {
            soldier.changeWeapon();
        }
        if (soldier._animation.IsPlaying(SoldierAnimation.name(SoldierAnimation.开火) + SoldierWeapon.name(soldier.currWeapon))) {

        } else if (fire) {
            soldier.fire();
            isAllowfireEffect = true;
        } else if (soldier.isJumping())
        {//防止后续动画覆盖一次性触发的跳起动画
            Debug.Log("jumping");
        }
        /*else if (soldier.isFalling())
        {//防止后续动画覆盖一次性下落的跳起动画
            Debug.Log("falling");
            if (!soldier._animation.IsPlaying(SoldierAnimation.name(SoldierAnimation.下落) + SoldierWeapon.name(soldier.currWeapon)))
            {
                soldier.fall();
            }
        }*/
        else if (space)
        {//一次性触发，下一帧不能被覆盖
            soldier.jump(speedJump);
        }
        else if (Mathf.Abs(v) > 0.1f || Mathf.Abs(h) > 0.1f)
        {
            soldier.run(new Vector2(h, v), speedRun);
        }
        else
        {
            //Debug.Log("standing");
            soldier.stand();
        }
    }
    private void _effect() {
        //Debug.Log("isAllowfireEffect=" + isAllowfireEffect);
        if (isAllowfireEffect) {
            fireEffectDelayTimeCount += Time.deltaTime;
            //Debug.Log("fireEffectDelayTimeCount=" + fireEffectDelayTimeCount);
            float fireEffectDelayTimeTemp = soldier.currWeapon == SoldierWeapon.火箭炮 ? fireEffectDelayTime * 5 : fireEffectDelayTime;
            if (fireEffectDelayTimeCount >= fireEffectDelayTimeTemp) {
                isAllowfireEffect = false;
                fireEffectDelayTimeCount = 0f;
                soldier.fireEffect();
            }
        }
    }
}
