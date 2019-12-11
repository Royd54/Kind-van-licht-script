using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text manaText;
    [SerializeField] private Image spiritUsageBar;
    private float playerHealth;
    private double spiritCharge;
    private double maxSpiritCharge;
    private int playerMana;


    // Update is called once per frame
    void Update()
    {
        //sets the ui elements to the correct values
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCombat>().getHealth();
        healthText.text = playerHealth + " / " + 20;

        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCombat>().getMana();
        manaText.text = playerMana + " / " + 7;

        GameObject.FindGameObjectWithTag("spirit").GetComponent<playerSpirit>().getCharge();

    }
}
