using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move_player : MonoBehaviour
{
    
    BoxCollider2D box;
    SpriteRenderer sr;
    private TMP_Text moneyText; //field money 

    public float speed = 5f;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sr =  GetComponent<SpriteRenderer>();
        moneyText = GameObject.FindGameObjectWithTag("HP").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        float movement_x = Input.GetAxis("Horizontal");
        float movement_y = Input.GetAxis("Vertical");

        if (movement_x != 0)
        {
            sr.flipX = movement_x < 0 ? true : false;
        }

        transform.position += new Vector3(movement_x, movement_y, 0) * speed * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    void OnCollisionEnter2D()
    {
        if (int.Parse(moneyText.text) > 1 )
        {
            moneyText.text =  (int.Parse(moneyText.text) - 1).ToString();
        }
        else{
            SceneManager.LoadScene(0);
        }
        
    }
}
