using UnityEngine;

public static class NetMessages
{
    public static float damage = 25f;
    public static float range = 1.5f;

    // CLIENT → HOST
    public static void SendAttack(Vector3 pos, Vector3 dir)
    {
        Debug.Log("[BaguetteMod] Attack envoyée au host");
        HostProcessAttack(pos, dir);
    }

    // HOST SIDE
    public static void HostProcessAttack(Vector3 pos, Vector3 dir)
    {
        Collider[] hits = Physics.OverlapSphere(pos, range);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Debug.Log("[BaguetteMod] Ennemi touché : " + hit.name);
                // var health = hit.GetComponent<EnemyHealth>();
                // health?.TakeDamage(damage);
            }
        }

        RpcPlayEffects(pos);
    }

    // EFFETS VISUELS
    public static void RpcPlayEffects(Vector3 pos)
    {
        Debug.Log("[BaguetteMod] FX au point " + pos);
        // TODO: particules, son, camera shake
    }
}
