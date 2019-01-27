using Assets.Weaponry;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public Transform firePoint;
    public string weaponName;
    public int weaponDamage;
    public Weapon currentWeapon;

    private void Start()
    {
        

        var ruby = new Augment("ruby", AugmentType.Gem);
        var runeOfOdin = new Augment("rune Of Odin", AugmentType.Rune);
        var runeOfThor = new Augment("rune of Thor", AugmentType.Rune);
        var augmentList = new List<Augment>() {ruby, runeOfOdin };
        this.currentWeapon = new Weapon("sword", WeaponClass.Set);
        this.currentWeapon.Augments.AddRange(augmentList);
        this.weaponDamage = this.currentWeapon.Damage;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit2D hit2DInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
           
        if(hit2DInfo)
        {
            TargetPractice targetPractice = hit2DInfo.transform.GetComponent<TargetPractice>();
            if (targetPractice != null)
                targetPractice.TakeDamage(this.weaponDamage, this.currentWeapon.ToString());
        }
    }
}
