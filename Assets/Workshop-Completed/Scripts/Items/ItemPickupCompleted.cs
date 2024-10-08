using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickupCompleted : MonoBehaviour
{
    [SerializeField] private GameObject keyBindObj;
    private TextMeshProUGUI keyBindText;
    [SerializeField] private ItemSO item;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool isPlayerInRange = false;

    private void Awake() {
        spriteRenderer.sprite = item.itemSprite;
        keyBindText = keyBindObj.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start(){
        keyBindObj.SetActive(false);
        keyBindText.text = "Press E to pick up " + item.itemName;
    }

    private void Update() {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E)){
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            keyBindObj.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            keyBindObj.SetActive(false);
            isPlayerInRange = false;
        }
    }

    public void PickUp(){
        Debug.Log("You picked up: " + item.itemName);
        Destroy(gameObject);
    }
}
