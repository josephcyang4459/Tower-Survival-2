using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] public Weapon weapon;
    [SerializeField] public bool readyToFire = true;
    public void Reset() {
        weapon.level = 0;
        weapon.trueRange = weapon.range / 112.5f;
        weapon.secondsBetweenAttacks = 2 / (1 + (weapon.atkSpeed / 100f));
        UpdateDamage(weapon.level);
        readyToFire = true;
    }

    public void Upgrade(int upgradeAmount = 1) {
        weapon.level += upgradeAmount;
        UpdateDamage(weapon.level);
    }

    // TODO There needs to be a clear separation between melee and ranged weapons

    public void Fire(GameObject target) {
        Debug.Log("Firing at: " + target.name);
        if (weapon.weaponType == WeaponType.Ranged) {
            GameObject newProjectile = Instantiate(weapon.projectile);
            ProjectileHandler projectileHandler = newProjectile.GetComponent<ProjectileHandler>();
            projectileHandler.target = target;
            projectileHandler.sourceWeapon = this;
        }
        else {
            DealDamage(target);
        }
        readyToFire = false;
        StartCoroutine(Reload());
    }

    public void DealDamage(GameObject target) {
        Health health = target.GetComponent<Health>();
        Shield shield = target.GetComponent<Shield>();

        if (shield != null && weapon.damage > shield.value) {
            shield.TakeDamage(shield.value);
            health.TakeDamage(weapon.damage - shield.value);
        } else {
            health.TakeDamage(weapon.damage);
        }
    }

    public void UpdateDamage(int weaponLevel) { weapon.damage = weapon.defaultDamage + (weaponLevel * weapon.damagePerLevel); }

    public bool WithinRange(GameObject origin, GameObject target) { return Vector3.Distance(origin.transform.position, target.transform.position) < weapon.trueRange; }

    IEnumerator Reload() {
        Debug.Log("Reloading " + weapon.name);
        yield return new WaitForSeconds(weapon.secondsBetweenAttacks);
        readyToFire = true;
        Debug.Log("Reloaded " + weapon.name);
    }
}
