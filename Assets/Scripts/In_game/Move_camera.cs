
using UnityEngine;


public class Move_camera : MonoBehaviour
{
    public Camera camera;
    public float speed=25f;
    public float scroll_speed=3;
    public Vector3 movement;
    public float scroll;
    public float max_x1;
    public float max_x2;
    public float max_y1;
    public float max_y2;
    public float min_scroll;
    public float max_scroll;
    void Update()
    {
        movement.x = 0;
        movement.y = 0;
        if(Input.GetKeyDown(KeyCode.G) && Input.GetKey(KeyCode.K))
        {
            max_x1=-999;
            max_x2=999;
            max_y1=999;
            max_y2=-999;
            min_scroll=0;
            max_scroll=999;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement.y += 1;
        } 
        if (Input.GetKey(KeyCode.S))
        {
            movement.y += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x += 1;
        } 
        if (Input.GetKey(KeyCode.A))
        {
            movement.x += -1;
        }
        movement = movement.normalized;
        scroll=Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            camera.orthographicSize-=scroll*scroll_speed;
            if(camera.orthographicSize>max_scroll){
                camera.orthographicSize=max_scroll;
            }
            if(camera.orthographicSize<min_scroll){
                camera.orthographicSize=min_scroll;
            }
            Vector2 transelate;
            transelate.x=0;
            transelate.y=0;
            Vector2 null_pos;
            null_pos.x=0;
            null_pos.y=0;
            if (transform.position.x-1.6*camera.orthographicSize<max_x1-1.6*max_scroll)
            { 
                transelate.x=1.6f;
            }
            if (transelate.x+transform.position.x+1.6*camera.orthographicSize>max_x2+1.6*max_scroll)
            {
                transelate.x=-1.6f;
            }
            if (transelate.y+transform.position.y+camera.orthographicSize>max_y1+1*max_scroll)
            {
                transelate.y=-1;
            }
            if (transelate.y+transform.position.y-camera.orthographicSize<max_y2-1*max_scroll)
            {
                transelate.y=1;
            }
            if(transelate != null_pos){
                transform.Translate(transelate);
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 transelate=movement*speed*Time.deltaTime;
        Vector2 null_pos;
        null_pos.x=0;
        null_pos.y=0;
        if (transelate == null_pos)
        {
            return;
        }   
        if (transelate.x+transform.position.x-1.6*camera.orthographicSize<max_x1-1.6*max_scroll)
        {
            transelate.x=0;
        }
        if (transelate.x+transform.position.x+1.6*camera.orthographicSize>max_x2+1.6*max_scroll)
        {
            transelate.x=0;
        }
        if (transelate.y+transform.position.y+camera.orthographicSize>max_y1+1*max_scroll)
        {
            transelate.y=0;
        }
        if (transelate.y+transform.position.y-camera.orthographicSize<max_y2-1*max_scroll)
        {
            transelate.y=0;
        }
        transform.Translate(transelate);
    }
}
