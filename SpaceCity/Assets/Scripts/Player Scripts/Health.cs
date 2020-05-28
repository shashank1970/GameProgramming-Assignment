using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health = 100f;
    private bool is_Dead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ApplyDamage(float damage)
    {
        // if we died don't execute the rest of the code
        if (is_Dead)
            return;

        health -= damage;

        //player_Stats.Display_HealthStats(health);

        if (health <= 0f)
        {

            PlayerDied();

            is_Dead = true;
        }

    }

    void PlayerDied(){ 

        Invoke("RestartGame", 3f);


    } // player died


    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("City");
    }





}
