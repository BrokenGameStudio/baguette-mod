using BepInEx;
using UnityEngine;

[BepInPlugin("com.pinpin25.baguettemod", "Baguette Mod", "1.0.0")]
public class MeleeWeaponMod : BaseUnityPlugin
{
    public static GameObject weaponPrefab;

    void Awake()
    {
        LoadBundle();
        Logger.LogInfo("[BaguetteMod] Loaded !");
    }

    void LoadBundle()
    {
        string path = System.IO.Path.Combine(
            System.IO.Path.GetDirectoryName(Info.Location),
            "baguette_assets"
        );

        var bundle = AssetBundle.LoadFromFile(path);

        if (bundle == null)
        {
            Logger.LogError("[BaguetteMod] AssetBundle introuvable ! Chemin : " + path);
            return;
        }

        weaponPrefab = bundle.LoadAsset<GameObject>("Baguette");

        if (weaponPrefab == null)
            Logger.LogError("[BaguetteMod] Prefab 'Baguette' introuvable dans le bundle !");
        else
            Logger.LogInfo("[BaguetteMod] Prefab Baguette chargé !");
    }
}
