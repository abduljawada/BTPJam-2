using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("DestroyHook", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.gameObject.tag == "Planet"){
        player.GetComponent<Player>().Follow(transform.position, transform.rotation);
        DestroyHook();
    }}

    void DestroyHook(){
        player.GetComponent<Player>().CanShoot(true);

        Destroy(this.gameObject);
    }
}
