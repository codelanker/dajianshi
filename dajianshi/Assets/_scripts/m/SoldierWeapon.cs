using UnityEngine;
using System.Collections;

public class SoldierWeapon
{
    public const int 手枪 = 0;
    public const int 步枪 = 1;
    public const int 机枪 = 2;
    public const int 火箭炮 = 3;
    public static string name(int id)
    {
        string name = "";
        switch (id)
        {
            case 手枪: name = "Pistol"; break;
            case 步枪: name = "Rifle"; break;
            case 机枪: name = "Heavy"; break;
            case 火箭炮: name = "Launcher"; break;
            default:break;
        }
        return name;
    }
    public static void effect(GameObject weapon,int weaponId,Transform camera) {
        SoldierWeaponEffect soldierWeaponEffect = weapon.GetComponent<SoldierWeaponEffect>();
        if (soldierWeaponEffect != null) {
            GameObject[] effects = soldierWeaponEffect.effects;
            if (effects != null && effects.Length > 0) {
                Vector3 position = weapon.transform.FindChild("p").position;
                GameObject.Instantiate(effects[0], position, Quaternion.identity);
            }
            if (effects != null && effects.Length > 1)
            {
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(camera.position, camera.forward, out hitInfo)) {
                   Object effect1 = GameObject.Instantiate(effects[1], hitInfo.point, Quaternion.identity);
                    GameObject.Destroy(effect1, weaponId == 火箭炮?1f:0.1f);
                }
            }
        }
    }
}
