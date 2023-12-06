using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
   [SerializeField] float maxHealth = 100;
   [SerializeField] float respawnTime;
   [SerializeField] GameObject healthPanel;
   [SerializeField] TMP_Text  healthText;
   [SerializeField] RectTransform healthBar;
   [SerializeField] MeshRenderer meshRenderer;
   float currHealth;
   float healthBarStartWidth;
   bool isDead;

   public void Start()
   {
      meshRenderer = GetComponent<MeshRenderer>();
      currHealth = maxHealth;
      healthBarStartWidth = healthBar.sizeDelta.x;
      UpdateUI();
   }

   public void ApplyDamage(float damage)
   {
      if(isDead) return;

      currHealth = currHealth - damage;
      Debug.Log(currHealth);

      if (currHealth <= 0)
      {
         currHealth = 0;
         isDead = true;
         meshRenderer.enabled = false;
         healthPanel.SetActive(false);

         StartCoroutine(RespawnAfterTime());
      }
      
      UpdateUI();
   }

   public IEnumerator RespawnAfterTime()
   {
      yield return new WaitForSeconds(respawnTime);
      ResetHealth();
   }

   public void ResetHealth()
   {
      currHealth = maxHealth;
      isDead = true;
      meshRenderer.enabled = true;
      healthPanel.SetActive(true);
   }

   public void UpdateUI()
   {
      float percentOutOf = (currHealth / maxHealth) * 100;
      float newWidth = (percentOutOf / 100) * healthBarStartWidth;

      healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);
      healthText.text = currHealth + "/" + maxHealth;
   }
}
