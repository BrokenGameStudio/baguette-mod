using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public Transform hitPoint;
    public float range = 1.5f;
    public float damage = 25f;
    public float cooldown = 0.6f;

    private float lastAttackTime;

    void Update()
    {
        if (!IsLocalPlayer()) return;

        if (Input.GetMouseButtonDown(0) && Time.time > lastAttackTime + cooldown)
        {
            lastAttackTime = Time.time;

            Vector3 pos = hitPoint != null ? hitPoint.position : transform.position;
            Vector3 dir = transform.forward;

            NetMessages.SendAttack(pos, dir);
        }
    }

    bool IsLocalPlayer()
    {
        // ⚠️ À remplacer par l'API R.E.P.O si nécessaire
        return true;
    }
}
