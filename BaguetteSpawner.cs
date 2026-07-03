using UnityEngine;
using HarmonyLib;

public class BaguetteWeapon : MonoBehaviour
{
    public float damage = 35f;
    public float swingCooldown = 0.6f;
    private float lastSwingTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > lastSwingTime + swingCooldown)
        {
            lastSwingTime = Time.time;
            Swing();
        }
    }

    void Swing()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        RaycastHit[] hits = Physics.RaycastAll(cam.transform.position, cam.transform.forward, 2.5f);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject == this.gameObject) continue;
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("[BaguetteMod] Ennemi touché : " + hit.collider.name);
                var enemy = hit.collider.GetComponent<EnemyHealth>();
                if (enemy != null) enemy.Hurt((int)damage, hit.collider.transform.position);
            }
        }
    }
}

[HarmonyPatch(typeof(LevelGenerator), "ItemSetup")]
public class BaguetteSpawner
{
    static void Postfix(LevelGenerator __instance)
    {
        try
        {
            if (MeleeWeaponMod.weaponPrefab == null)
            {
                Debug.LogError("[BaguetteMod] Prefab manquant !");
                return;
            }

            GameObject itemParent = __instance.ItemParent;
            if (itemParent == null)
            {
                Debug.LogError("[BaguetteMod] ItemParent null !");
                return;
            }

            Vector3 spawnPos = itemParent.transform.position + new Vector3(
                Random.Range(-3f, 3f),
                1f,
                Random.Range(-3f, 3f)
            );

            GameObject baguette = GameObject.Instantiate(
                MeleeWeaponMod.weaponPrefab,
                spawnPos,
                Quaternion.identity,
                itemParent.transform
            );

            // Taille correcte
            baguette.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            // Ajoute Rigidbody pour la physique
            Rigidbody rb = baguette.GetComponent<Rigidbody>();
            if (rb == null)
                rb = baguette.AddComponent<Rigidbody>();
            rb.mass = 1f;
            rb.useGravity = true;

            // Ajoute PhysGrabObject pour pouvoir la ramasser
            PhysGrabObject grabObj = baguette.GetComponent<PhysGrabObject>();
            if (grabObj == null)
                grabObj = baguette.AddComponent<PhysGrabObject>();

            // Ajoute le script d'attaque
            if (baguette.GetComponent<BaguetteWeapon>() == null)
                baguette.AddComponent<BaguetteWeapon>();

            // Enregistre dans ItemManager
            var itemAttribs = baguette.GetComponent<ItemAttributes>();
            if (ItemManager.instance != null && itemAttribs != null)
                ItemManager.instance.AddSpawnedItem(itemAttribs);

            Debug.Log("[BaguetteMod] Baguette spawned et grabbable !");
        }
        catch (System.Exception e)
        {
            Debug.LogError("[BaguetteMod] Erreur : " + e.Message);
        }
    }
}
