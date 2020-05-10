using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 _direction;//鼠标方向
    Transform _transform;
    Camera _camera;
    //自毁计时器
    /*public float _timer=5;*/ //放到Controller那边去了 -包
    public float _speed=1;
    
    
    //We set values in a Init method. Virtual, so we can extend it later :)
    public virtual Projectile Init(Vector3 direction){
        this._direction = direction;
        /*Destroy(this,_timer);*///我不确定放这里还是start //我写到PlayerController那边去了，这样在运行的时候可以看到那些GameObject都被删掉了 -包
        /*
        Your Code here
        */
        //normalized 使所有激光的飞行速度保持一致 -包
        this.transform.position +=  (this._direction.normalized) * _speed  * Time.deltaTime; // -包
        return this;
    }

    void Start()
    {
        
        this._transform = this.transform;
        this._camera = Camera.main;
        this.Rotate();
        Vector _mousePos = new Vector3(this._camera.ScreenToWorldPoint(Input.mousePosition).x - this._transform.position.x, 
                                       this._camera.ScreenToWorldPoint(Input.mousePosition).y - this._transform.position.y, 0); // -包
    }

    void Update()
    {
        _transform.Translate(_direction*Time.deltaTime*_speed);
        this.Rotate(); //不知道为什么，反正我这里还需要Rotate，不然我的Projectile就很怪 -包
        this.Init(_mousePos); // -包
    }

    
    void Rotate(){
        Vector3 pos = this._transform.position + this._direction;
        float AngleRad = Mathf.Atan2(pos.y - this._transform.position.y, pos.x - this._transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this._transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }
}
