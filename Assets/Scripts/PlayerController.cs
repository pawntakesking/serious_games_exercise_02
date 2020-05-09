using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Transform _transform;
    Camera _camera;
    public float speed =2;
    float x,y;
    /*public float _speed;*/
    public GameObject _prefab; //-包

    void Start()
    {
        this._transform = transform;
        this._camera = Camera.main;
    }

    //Standard UpdateLoop (once per Frame)
    void Update()
    {
        this.Rotate();
        //目前不知道wasd方向是哪个对应xyz，所以先这样写，之后确定了再修改
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

        transform.Translate(new Vector3(x,y,0),Space.World);
        //这样应该可以了
        
        /*this.move();*/ 
         if(Input.GetMouseButtonDown(0)){
            Debug.Log("Left Mouse clicked");
            GameObject clone = Instantiate(_prefab, this._transform.position, Quaternion.identity) as GameObject;
            } //左键的时候发射激光 -包   
    }

    void Rotate(){
        Vector2 mousePos = this._camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - this._transform.position.y, mousePos.x - this._transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        this._transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90);//diese -90 sind nötig für Sprites, die nach oben zeigen. Nutzen Sie andere Assets, könnte es sein, dass die das anpassen müssen
        
    }
     //这是我的版本，上传上来看看
     /*void move(){
       
        float _horizontalInput = Input.GetAxis("Horizontal");
        
        float _verticalInput = Input.GetAxis("Vertical");
       
        _transform.position = _transform.position + new Vector3(_horizontalInput * _speed * Time.deltaTime, _verticalInput * _speed * Time.deltaTime, 0);
      
        Debug.Log(_transform.position);
    }*/ //-包

}
