using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour

{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip;
    [SerializeField] private AudioClip _dropClip;


    private bool _dragging, _placed;
    private Vector2 _offset, _originalPosition;
    private PuzzleSlot _slot;

    public void Init(PuzzleSlot _slot)
    {
        _renderer.sprite = _slot.Renderer.sprite;
      
    }

    private void Awake()
    {
        _originalPosition = transform.position;
    }
   

    // Update is called once per frame
    void Update()
    {
        if (_placed) return;
        if (!_dragging) return;
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;
    }
  
    private void OnMouseDown()
    {
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);
        _offset = GetMousePos() - (Vector2)transform.position;
    }
   private void OnMouseUp()
    {
        if (Vector2.Distance(transform.position, _slot.transform.position) < 4)
        {
            transform.position = _slot.transform.position;
            _slot.Placed();
            _placed = true;

        }else
        {
            transform.position = _originalPosition;
            _dragging = false;
        }
       }
       
    
    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
