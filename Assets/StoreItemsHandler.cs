using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemsHandler : MonoBehaviour {
    [SerializeField] List<Item> possibleItems;
    [SerializeField] List<GameObject> currentItems;
    [SerializeField] GameObject dividerPrefab;
    [SerializeField] GameObject itemDetailPrefab;
    [SerializeField] GameObject bottomFiller;

    void Start() {
        EventHandler.inst.goToNextWave.AddListener(RefreshStoreItems);
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            currentItems.Add(gameObject.transform.GetChild(i).gameObject);
        }

        RefreshStoreItems();
    }

    void OnDestroy() { EventHandler.inst.goToNextWave.RemoveListener(RefreshStoreItems); }

    public void RefreshStoreItems() {
        foreach (GameObject item in currentItems) {
            Item generatedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            item.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => PlayerHandler.inst.UpgradeItem(generatedItem));
            // This would be where the image is changed. Current there are no images, hence why the text is changed instead
            item.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = generatedItem.ToString();

            // This changes item details when item is hovered
            if (generatedItem.GetType() == typeof(Weapon))
                item.GetComponent<StoreItem>().ChangeOnHoverItemDescription((Weapon) generatedItem);
            else
                item.GetComponent<StoreItem>().ChangeOnHoverItemDescription((Buff) generatedItem);
        }
    }
}
