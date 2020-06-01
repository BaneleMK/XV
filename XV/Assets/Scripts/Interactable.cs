using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;
    public float turnSpeed = 10f;
    public float objectSpeed = 5f;

    bool isfocus = false;
    bool hasinteracted = false;
    Transform player;
    PlayerMotor playerMotor;

    private void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();   
    }

    private void Update()
    {
        if (isfocus)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance < radius && !hasinteracted)
            {
                Debug.Log("interactttttttt");
                hasinteracted = true;
            }
        }
    }

    public void OnFocused (Transform playertransform)
    {
        isfocus = true;
        player = playertransform.transform;
    }

    public void sethasinteractedfalse()
    {
        hasinteracted = false;
    }

    public bool gethasinteracted()
    {
        return hasinteracted;
    }

    public void OnDefocused()
    {
        isfocus = false;
        player = null;
        hasinteracted = false;
    }

    public void interact()
    {

    }

    public void destroyObject()
    {
        Object.Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}
