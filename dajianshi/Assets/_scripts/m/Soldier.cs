using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Soldier : MonoBehaviour, IPlayer
{

    public GameObject soldier;
    public GameObject[] weapons;
    public Animation _animation;
    public Rigidbody rigid;
    public Transform _camera;
    public GameObject star;

    public int currWeapon = 0;
    

    public void changeWeapon()
    {
        int total = weapons.Length;
        weapons[currWeapon].SetActive(false);
        currWeapon = currWeapon == total - 1 ? 0 : currWeapon+1;
        weapons[currWeapon].SetActive(true);
    }

    public void fire()
    {
        _animation.CrossFade(SoldierAnimation.name(SoldierAnimation.开火) + SoldierWeapon.name(currWeapon), currWeapon==SoldierWeapon.机枪?0.01f:0.2f);
            
    }
    public void fireEffect() {
        SoldierWeapon.effect(weapons[currWeapon],currWeapon,_camera);
    }

    public void jump(float speed)
    {
        _animation.CrossFade(SoldierAnimation.name(SoldierAnimation.跳起)+SoldierWeapon.name(currWeapon),0.01f);
        float x = -rigid.velocity.x / 3;
        float z = -rigid.velocity.z / 3;
        float y = Mathf.Max(Mathf.Abs(x), Mathf.Abs(z)) * 2;
        y=y < 1?1:(y>2?2:y);
        rigid.AddRelativeForce(
            new Vector3(x,y,z)
            * speed);
    }
    public void fall() {
        Debug.Log("start fall ing");
        _animation.CrossFade(SoldierAnimation.name(SoldierAnimation.下落) + SoldierWeapon.name(currWeapon), 0.01f);
        rigid.AddRelativeForce(
            new Vector3(0,
            -90,
           0));
    }
    private float height() {
        float height = 0.0f;
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(soldier.transform.position, soldier.transform.up * -1, out hitInfo))
        {
            height = Vector3.Distance(soldier.transform.position, hitInfo.point);
        }
        //Debug.Log("height="+height+" position="+ soldier.transform.position + "  hitInfo.point=" + hitInfo.point);
        return height;
    }
    public bool isJumping() {//跳起动画播放中或高度大于0.5f，且y方向速度大于等于0
        float h = height();
        //Debug.Log("height=" + h + "   rigid.velocity.y=" + rigid.velocity.y);
        //return (_animation.IsPlaying(SoldierAnimation.name(SoldierAnimation.跳起) + SoldierWeapon.name(currWeapon))||height()>0.5f)&&rigid.velocity.y>=0;
        //去除下落动作
        return _animation.IsPlaying(SoldierAnimation.name(SoldierAnimation.跳起) + SoldierWeapon.name(currWeapon)) || h> 0.5f;

    }
    public bool isFalling()
    {
        float h = height();
        //Debug.Log("height="+h+ "   rigid.velocity.y="+rigid.velocity.y);
        return h > 0.5f && rigid.velocity.y < 0 ;
    }
    public void run(Vector2 direct, float speed)
    {
        int animatId = -1;
        if (direct.y > 0.1f)
        {
            animatId = SoldierAnimation.前走;
        }
        else if (direct.y < -0.1f)
        {
            speed = speed / 1.4f;
            animatId = SoldierAnimation.后退;
        }
        else {
            if (direct.x > 0.1f)
            {
                speed = speed / 2f;
                animatId = SoldierAnimation.右移;
            }
            else if (direct.x < -0.1f) {
                speed = speed / 2f;
                animatId = SoldierAnimation.左移;
            }
        }
        //Debug.Log("direct=" + direct);
        //Debug.Log("animatId=" + animatId);
        if (animatId > 0) {
            _animation.CrossFade(SoldierAnimation.name(animatId)+SoldierWeapon.name(currWeapon), 0.2f);
            rigid.AddRelativeForce(new Vector3(direct.x, 0,direct.y )*speed);
        }

       
    }
    
    public void stand()
    {
       
            _animation.CrossFade(SoldierAnimation.name(SoldierAnimation.站立)+SoldierWeapon.name(currWeapon), 0.1f);
    
    }
    public  void rotate(int direct, float speed) {
        soldier.transform.Rotate(Vector3.up*speed*direct);
    }
}
