using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoldierStar
{
    public static void rotate(GameObject target,float rotateSpeed) {
        target.transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }
    public static void changeColre(GameObject target,Transform origin, Color c0, Color c1) {
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(origin.position, origin.forward, out hitInfo)
            && hitInfo.collider.CompareTag("enemy"))
        {
            target.GetComponent<Image>().color = c1;
        }
        else {
            target.GetComponent<Image>().color = c0;
        }
    }

    public static void scale(GameObject target) {
        iTween.ScaleTo(target, iTween.Hash("scale", new Vector3(1, 1, 1), "time",1f,"looptype",iTween.LoopType.pingPong));
    }
}
