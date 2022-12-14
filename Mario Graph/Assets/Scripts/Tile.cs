using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private int _ID;

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter()
    {
        Debug.Log ("entered");
        _highlight.SetActive(true);
        

    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    public int getID(){
        return _ID;
    }

    public void setID(int ID){
        this. _ID = ID;
    }

}
