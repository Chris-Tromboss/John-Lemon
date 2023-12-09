using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowClone : MonoBehaviour
{
    public GameObject player;
    public List<Vector3> playerPosition;
    public List<Quaternion> playerRotation;
    public List<bool> playerWalking;

    public GameObject visible;

    Animator m_Animator;
    
    Vector3 position;
    Quaternion rotation;

    void Start()
    {
        m_Animator = GetComponent<Animator> ();
        visible.GetComponent<Renderer>().enabled = false;
        Invoke("Appear", 3);
    }


    void FixedUpdate()
    {
        playerPosition.Add(player.transform.position);
        playerRotation.Add(player.transform.rotation);
        playerWalking.Add(PlayerMovement.isWalking);

        
        
        if(playerWalking.Count == 120){
            bool temp = playerWalking[0];
            //Debug.Log(temp);
            m_Animator.SetBool ("IsWalking", temp);
            playerWalking.RemoveAt(0);
        }
        
        if(playerPosition.Count == 120){
            Vector3 destination = playerPosition[0];
            //Debug.Log(destination);
            transform.position = destination;
            playerPosition.RemoveAt(0);
        }
        
        if(playerRotation.Count == 120){
            Quaternion destination = playerRotation[0];
            //Debug.Log(destination);
            transform.rotation = destination;
            playerRotation.RemoveAt(0);
        }
    }

    void Appear(){
        visible.GetComponent<Renderer>().enabled = true;
    }
}
