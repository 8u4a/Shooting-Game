using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    public int Health { get; set; }
    public int ArmourPercent { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        this.Health = 99999999;
        this.ArmourPercent = 34;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    public override string ToString()
    {
        return $"Target has {this.Health} left";
    }

    internal void TakeDamage(int incomingDamage, string weaponDescription)
    {
        var calculatedDamage = GetIncomingDamageFrom(incomingDamage);
        this.Health = this.Health - calculatedDamage;
        
        //this.Health = this.Health - CalculateDamageBasedOnArmour() (incomingDamage - Armour);

        //eg. incomingDmg = 100 and armour = 0 -> totalDmg = 100
        //eg. incomingDmg = 100 and armour = 34 -> totalDmg = incomingDmg - Math.round(incomingDmg*34/100);

        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        var txtDmgTaken = canvasObject.transform.Find("TextDamageTaken");
        var componentTxtDaamgetaken = txtDmgTaken.GetComponent<TextMeshProUGUI>();
        componentTxtDaamgetaken.SetText($"{calculatedDamage}");

        StartCoroutine(FadeTextToZeroAlpha(.2f, componentTxtDaamgetaken));

        var txtRemainingHealth = canvasObject.transform.Find("TextRemainingHealth");
        var componentTxtRemainingHealth = txtRemainingHealth.GetComponent<TextMeshProUGUI>();
        componentTxtRemainingHealth.SetText(this.ToString());


        var txtAttackStatus = canvasObject.transform.Find("TextAttackStatus");
        var componentTxtAttackStatus = txtAttackStatus.GetComponent<TextMeshProUGUI>();
        componentTxtAttackStatus.SetText(weaponDescription);
    }


    private int GetIncomingDamageFrom(int incomingDamage)
    {
        decimal dmgCalc = incomingDamage * ArmourPercent / 100;
        var totalDmg = incomingDamage - Math.Round(dmgCalc);
        Debug.Log(totalDmg);
        return Convert.ToInt32(totalDmg);
        
    
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
