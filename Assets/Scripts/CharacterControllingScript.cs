using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllingScript : MonoBehaviour
{
    [SerializeField] private float JUMP_POWER;
    [SerializeField] private float RUN_SPEED;

    private Rigidbody2D playerRig;
    private Quaternion newRotation;

    private void Awake()
    {
        newRotation = this.transform.rotation;
        playerRig = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))playerRig.AddForce(new Vector2(0, JUMP_POWER));


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.rotation.y >= 0)
            {
                newRotation.y = -180;
                this.transform.rotation = newRotation;
            }
            playerRig.AddForce(new Vector2(RUN_SPEED.ReflectValue(),0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.transform.rotation.y <= 0)
            {
                newRotation.y = 0;
                this.transform.rotation = newRotation;
            }
            playerRig.AddForce(new Vector2(RUN_SPEED, 0));
        }
    }
}
