using UnityEngine;
using System.Collections;

public interface IPlayer{
    void stand();
    void run(Vector2 direct,float speed);
    void jump(float speed);
    void fall();
    bool isJumping();
    bool isFalling();
    void fire();
    void changeWeapon();
    void rotate(int direct, float speed);

}
