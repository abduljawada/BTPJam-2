using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public float offset;
    public GameObject rope;
    public GameObject particles;
    public Transform shotPoint;
    public static bool canShoot;
    int scoreValue;
    public Text score;
    public AudioClip death;
    // Update is called once per frame
    void Start(){
        gameObject.GetComponent<SpriteRenderer>().enabled=true;
        Time.timeScale=1;
        scoreValue = 0;
        canShoot = true;

    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if(canShoot == true) {
        
            if(Input.GetMouseButtonDown(0)) {
                Instantiate(rope, shotPoint.position, transform.rotation);
                canShoot = false;
            }
        }
    }

    public void CanShoot(bool state) {
        canShoot = state;
    }

    public void Follow(Vector3 pos, Quaternion rot){
        transform.rotation = rot;
        transform.position = pos;
    }

    IEnumerator OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            gameObject.GetComponent<SpriteRenderer>().enabled=false;
            Instantiate(particles, transform.position, transform.rotation);
            gameObject.AddComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(death, transform.position);
            Time.timeScale = 0.1f;
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(0);
        }
    }

    public void Score(){
        scoreValue ++;
        score.text = scoreValue.ToString();
    }
}