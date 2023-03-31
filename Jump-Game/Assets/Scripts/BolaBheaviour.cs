using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaBheaviour: MonoBehaviour {

    Rigidbody rbBola;
    float bounceTime = 3f, speed = -5f;
    bool goUp = false;
    // Start is called before the first frame update
    void Start () {
        rbBola = gameObject.GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {
        if (goUp == true) {
            if (Mathf.Floor (bounceTime) >= 0f) {
                bounceTime -= Time.deltaTime;
                speed -= bounceTime / speed;
            } else if (bounceTime < 0f) {
                goUp = false;
                speed = -speed;
                bounceTime = 3f;
            }
        } else {
            if (Mathf.Floor (speed) > -5f) {
                speed += Time.deltaTime * 9.8f;
            }
        }
    }

    private void FixedUpdate () {
        rbBola.velocity = new Vector3 (0f, speed, 0f);
        rbBola.MovePosition (transform.position + rbBola.velocity * Time.deltaTime);
    }

    private void OnCollisionEnter (Collision collision) {
        goUp = true;
        speed = -speed;
    }
}
