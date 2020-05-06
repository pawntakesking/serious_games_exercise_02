using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Transform _transform;
    Camera _camera;
    public float speed =2;
    float x,y;

    void Start()
    {
        this._transform = transform;
        this._camera = Camera.main;
    }

    //Standard UpdateLoop (once per Frame)
    void Update()
    {
        this.Rotate();
        if(Input.GetKey(KeyCode.W))
        {
            y=speed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            y=-speed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            x=speed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            x=-speed*Time.deltaTime;
        }

        transform.Translate(new Vector2(x,y),Space.Self)
    }

    void Rotate(){
        Vector2 mousePos = this._camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - this._transform.position.y, mousePos.x - this._transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        this._transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90);//diese -90 sind nötig für Sprites, die nach oben zeigen. Nutzen Sie andere Assets, könnte es sein, dass die das anpassen müssen
        
    }
}
