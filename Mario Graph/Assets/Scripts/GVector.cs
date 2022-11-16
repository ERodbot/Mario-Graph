using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GVector : MonoBehaviour
{


    private bool _dragging;
    private bool _isChild;
    private Vector3 position;
    private bool isPositioned;
    private Vector2 _offset;

    void Update(){
        if(!_isChild && !isPositioned){
            position = transform.position;
            isPositioned = true;
        } 
        if(!_dragging) return;
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;
    }

    void Start(){

    }
    

    void OnMouseDown(){
        _dragging  = true;
        Debug.Log("mouse down");
        _offset = GetMousePos() - (Vector2)transform.position;
        
    }

    void OnMouseUp(){
       _dragging = false;
       var createCopyOfOriginal = Instantiate(this);
       _isChild = true;
       createCopyOfOriginal.SetPosisiton(position);
       createCopyOfOriginal.position = position;
      
    }   

    void set_isChild(bool isChild){
        _isChild = isChild;
    }
    

    Vector3 GetPosisiton(){
        return position;
    }

    void SetPosisiton(Vector3 _pos){
        position = _pos;
    }

    Vector2 GetMousePos(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Start is called before the first frame update
   

    // Update is called once per frame
  
}
