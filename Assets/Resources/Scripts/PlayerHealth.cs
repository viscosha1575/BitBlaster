using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int ammountShields;
    public GameObject shipSprite;
    public float invincibleTime;
    public GameObject[] shieldSprites;
    public Score score;
    bool invincible = false;
    // DAMAGE
    public void TakeDamage()
    {
        if (!this.invincible)
        {
            this.ammountShields--;
            if (this.ammountShields < 0)
            {
                this.DestoyShip();
                Debug.Log("destroy");
            }
            else
            {
                StartCoroutine(this.InvincibleAfterDamage());
                Debug.Log("invincible");
            }
        }
    }
    public void DestoyShip()
    {
        score = GameObject.FindWithTag("Score").GetComponent<Score>();
        PlayerPrefs.SetInt("highscore", score.currentScore);
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("TRIGGGERRRR");
    }
    public IEnumerator InvincibleAfterDamage()
    {
        this.invincible = true;
        Debug.Log("invincible");
        float invisTime = invincibleTime / 8;
        for (int i = 0; i < 4; i++)
        {
            this.shipSprite.SetActive(false);
            yield return new WaitForSeconds(invisTime);
            this.shipSprite.SetActive(true);
            yield return new WaitForSeconds(invisTime);
        }
        this.invincible = false;
        Debug.Log("not invincible");
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < this.ammountShields)
            {
                this.shieldSprites[i].SetActive(true);
            }
            else
            {
                this.shieldSprites[i].SetActive(false);
            }
        }
    }
}
