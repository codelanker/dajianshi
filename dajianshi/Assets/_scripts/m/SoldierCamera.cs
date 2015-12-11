using UnityEngine;
using System.Collections;

public class SoldierCamera
{
    public static void rotateX(int direct,float speed,Transform target,Vector2 rangeRotateCameraX) {
        float cameraEngle = target.localEulerAngles.x+ direct * speed;
        Debug.Log("cameraEngle=" + cameraEngle);
        Debug.Log("cameraEngle > rangeRotateCameraX.x && cameraEngle < rangeRotateCameraX.y = " + (cameraEngle > rangeRotateCameraX.x && cameraEngle < rangeRotateCameraX.y));

        if (cameraEngle > rangeRotateCameraX.x && cameraEngle < rangeRotateCameraX.y) {
            target.Rotate(Vector3.right*direct*speed);
        }
    }
}
