using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemsHandler : MonoBehaviour {
    [SerializeField] List<ScriptableObject> possibleItems;
    [SerializeField] List<GameObject> currentItems;

    void Start() {
        EventHandler.inst.goToNextWave.AddListener(RefreshStoreItems);
        for (int i = 0; i < gameObject.transform.childCount; i++)
            currentItems.Add(gameObject.transform.GetChild(i).gameObject);

        RefreshStoreItems();
    }

    void OnDestroy() { EventHandler.inst.goToNextWave.RemoveListener(RefreshStoreItems); }

    public void RefreshStoreItems() {
        foreach (GameObject item in currentItems) {
            ScriptableObject generatedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            item.GetComponent<Button>().onClick.AddListener(() => PlayerHandler.inst.UpgradeItem(generatedItem));
            item.GetComponentInChildren<TextMeshProUGUI>().text = generatedItem.ToString();
        }
    }
}