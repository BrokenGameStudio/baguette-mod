using UnityEngine;

public static class WeaponSpawner
{
    public static GameObject Spawn(Transform hand)
    {
        if (MeleeWeaponMod.weaponPrefab == null)
        {
            Debug.LogError("[BaguetteMod] Prefab manquant !");
            return null;
        }

        GameObject weapon = GameObject.Instantiate(MeleeWeaponMod.weaponPrefab);

        weapon.transform.SetParent(hand);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;

        Debug.Log("[BaguetteMod] Baguette spawned !");
        return weapon;
    }
}
