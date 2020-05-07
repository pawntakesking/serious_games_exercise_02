using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Transform _transform;
    Camera _camera;
    public float speed =2;
    float x,y;
    /*public float _speed;*/

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

        transform.Translate(new Vector3(x,y),Space.Self)；
        //注意这里是中文分号，代码要编译完了跑通了再上传
        //另外这里Space.self是不符合演示的，演示的情况AWSD应该在世界坐标系下移动而不是Object坐标系
        
        /*this.move();*/
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
    }*/

}
