using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceImagesHandler : MonoBehaviour
{
    [SerializeField] Sprite placeSelected; 
    [SerializeField] Sprite placeNotSelected;
    private SpriteRenderer spriteRenderer;
    public Sprite menuImage {get;set;} // Imagem do lugar no menu;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            Debug.LogError($"SpriteRenderer não encontrado em {gameObject.name}");
    }

    void Start()
    {
        spriteRenderer.sprite = placeSelected;
    }

    public void UpdateSelection(bool isSelected)
    {
        if (isSelected)
            spriteRenderer.sprite = placeSelected;
        else
            spriteRenderer.sprite = placeNotSelected;
    }
}
