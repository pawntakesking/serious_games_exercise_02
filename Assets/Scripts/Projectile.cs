using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 _direction;//鼠标方向
    Transform _transform;
    Camera _camera;
    //自毁计时器
    public float _timer=5;
    public float _speed=1;
    
    //We set values in a Init method. Virtual, so we can extend it later :)
    public virtual Projectile Init(Vector3 direction){
        this._direction = direction;
        Destroy(this,_timer);//我不确定放这里还是start
        /*
        Your Code here
        */
        return this;
    }

    void Start()
    {
        
        this._transform = this.transform;
        this._camera = Camera.main;
        this.Rotate();
    }

    void Update()
    {
        _transform.Translate(_direction*Time.deltaTime*_speed);
    }

    
    void Rotate(){
        Vector3 pos = this._transform.position + this._direction;
        float AngleRad = Mathf.Atan2(pos.y - this._transform.position.y, pos.x - this._transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this._transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }
}
