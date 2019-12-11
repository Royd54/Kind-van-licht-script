using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemyCombat : MonoBehaviour
{

    public AudioManager AudioManager;
    public GameObject DamageNumbers;

    public float enemyHealth = 50f;
    public float canAttack;
    private float strength;
    [SerializeField] private GameObject enemySlider;
    [SerializeField] private float curentUIpos;

    

    // Start is called before the first frame update
    void Start()
    {
        canAttack = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        //updates the position of the attack UI knob
        curentUIpos = enemySlider.GetComponent<Slider>().value;
        enemySlider.GetComponent<Slider>().value = Mathf.Lerp(curentUIpos, canAttack, Time.deltaTime * 10);
        //enemySlider.GetComponent<Slider>().value = Mathf.MoveTowards(enemySlider.GetComponent<Slider>().value, canAttack, 100.0f);

        //if the enemy is dead the player XP is added
        if (enemyHealth <= 0)
        {

           GameObject.Find(contstantsClass.player).GetComponent<playerCombat>().addXP();
           this.gameObject.SetActive(false);

            AudioManager.FXAudio(3);

            if (DamageNumbers != null)
            {
                //Set damage number active.
                DamageNumbers.SetActive(true);
            }
        }

        //if the enemy can attack it deals damage to the player
        if (canAttack >= 100 && GameObject.Find(contstantsClass.player).GetComponent<playerCombat>().attacking == false)
        {
            strength = Random.Range(1, 7);
            Debug.Log(strength);
            //anim met courantine
            if (GameObject.Find(contstantsClass.player).GetComponent<playerCombat>().blocking == true)
            {
                strength /= 2;
                canAttack -= 50;
                Debug.Log(strength /= 2);
            }
            canAttack -= 50;
            GameObject.Find(contstantsClass.player).GetComponent<playerCombat>().recieveDamage(Mathf.CeilToInt(strength));
        }
   
    }

    //getter for the damage taken by the player and adds canAttack, so it can attack faster
    public void getDamage(float damage){
        enemyHealth -= damage;
        Debug.Log("enemyHealth: " + enemyHealth);
        canAttack += 40;
    }
}
