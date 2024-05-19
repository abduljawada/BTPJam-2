using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed;
    GameObject player;
    public GameObject particles;
    int scoreValue;




    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        speed = Random.RandomRange(1f,3f);
        Debug.Log(speed);
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = player.transform.rotation;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Planet"){
            player.GetComponent<Player>().Score();
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
}
