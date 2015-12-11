using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public bool tab;
    public bool space;
    public bool a;//摄像头左移动
    public bool d;//摄像头右移动
    public bool c;//摄像头上移
    public bool z;//摄像头下移动
    public bool fire;
    public float v;
    public float h;

    public SoldierController soldierController;

    void Update()
    {
        getValues();
        soldierController.go(v,h,tab,space,a,d,c,z,fire);
    }
    private void getValues() {
        tab = Input.GetKeyDown(KeyCode.Tab);
        space = Input.GetKeyDown(KeyCode.Space);
        a = Input.GetKey(KeyCode.A);
        d = Input.GetKey(KeyCode.D);
        c = Input.GetKey(KeyCode.C);
        z = Input.GetKey(KeyCode.Z);
        fire = Input.GetMouseButtonDown(1);
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        /*Debug.Log(
            "tab="+tab+"  "+
            "space=" + space + "  " +
            "v=" + v + "  " +
            "h=" + h + "  " 
            );*/
    }
}
