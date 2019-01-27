using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        this.Health = 99999999;

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
        this.Health = this.Health - incomingDamage;
        

        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        var txtDmgTaken = canvasObject.transform.Find("TextDamageTaken");
        var componentTxtDaamgetaken = txtDmgTaken.GetComponent<TextMeshProUGUI>();
        componentTxtDaamgetaken.SetText($"{incomingDamage}");

        StartCoroutine(FadeTextToZeroAlpha(.2f, componentTxtDaamgetaken));

        var txtRemainingHealth = canvasObject.transform.Find("TextRemainingHealth");
        var componentTxtRemainingHealth = txtRemainingHealth.GetComponent<TextMeshProUGUI>();
        componentTxtRemainingHealth.SetText(this.ToString());


        var txtAttackStatus = canvasObject.transform.Find("TextAttackStatus");
        var componentTxtAttackStatus = txtAttackStatus.GetComponent<TextMeshProUGUI>();
        componentTxtAttackStatus.SetText(weaponDescription);
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
