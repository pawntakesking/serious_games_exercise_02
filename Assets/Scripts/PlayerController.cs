using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float _speed;
    
    public GameObject _prefab;
    Transform _transform;
    Camera _camera;
    float _destroyTime = 5f;
    float _cd = 1f;
    float _ready = 0f;

    

    void Start()
    {
        this._transform = transform;
        this._camera = Camera.main;
        
    }

    //Standard UpdateLoop (once per Frame)
    void Update()
    {
        this.Rotate();   
        this.move();
        if(Input.GetMouseButtonDown(0) && Time.time > _ready){
            Debug.Log("Left Mouse clicked");
            _ready = Time.time + _cd;
            Debug.Log("Time added");
            GameObject clone = Instantiate(_prefab, this._transform.position, Quaternion.identity) as GameObject;
            Destroy(clone, this._destroyTime);
        }
    }
    
    

    void Rotate(){
        Vector2 mousePos = this._camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - this._transform.position.y, mousePos.x - this._transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        this._transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90);//diese -90 sind nötig für Sprites, die nach oben zeigen. Nutzen Sie andere Assets, könnte es sein, dass die das anpassen müssen
        
    }


    void move(){
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");
        //update the position
        _transform.position = _transform.position + new Vector3(horizontalInput * _speed * Time.deltaTime, verticalInput * _speed * Time.deltaTime, 0);
        //output to log the position change
        Debug.Log(_transform.position);
    }

    

}
