using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class StoreItemsHandler : MonoBehaviour {
    [SerializeField] Item refreshItem;
    [SerializeField] List<Item> possibleItems;
    [SerializeField] List<GameObject> currentItems;
    [SerializeField] float refreshTime;
    [SerializeField] Slider TimerSlider;
    [SerializeField] GameObject dividerPrefab;
    [SerializeField] GameObject itemDetailPrefab;
    [SerializeField] GameObject bottomFiller;

    float currentRefreshTime;

    void Start() {
        // The first item is always the refresh item, hence why we skip it in favor of actual store items
        for (int i = 1; i < gameObject.transform.childCount; i++) {
            currentItems.Add(gameObject.transform.GetChild(i).gameObject);
        }

        currentRefreshTime = refreshTime;
        StartCoroutine(RefreshStoreItemsCoroutine());
    }

    IEnumerator RefreshStoreItemsCoroutine() {
        // Reset refresh item
        PlayerHandler.inst.GetComponent<RefreshHandler>().Reset();
        RefreshStoreItems();

        while (currentRefreshTime > 0) {
            yield return new WaitForSeconds(Time.deltaTime);
            currentRefreshTime -= Time.deltaTime;
            TimerSlider.value = currentRefreshTime / refreshTime;
        }

        currentRefreshTime = refreshTime;

        StartCoroutine(RefreshStoreItemsCoroutine());
    }

    public void RefreshStoreItems() {
        gameObject.transform.GetChild(0).gameObject.GetComponent<StoreItem>().ChangeOnHoverItemDescription(refreshItem);

        foreach (GameObject item in currentItems) {
            // Makes item visible
            item.GetComponent<CanvasGroup>().alpha = 1;

            // Picks a random upgrade to make available
            Item generatedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            item.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => PlayerHandler.inst.UpgradeItem(generatedItem));

            // This would be where the image is changed. Current there are no images, hence why the text is changed instead
            item.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = generatedItem.ToString();

            // This changes item details when item is hovered
            item.GetComponent<StoreItem>().ChangeOnHoverItemDescription(generatedItem);
        }
    }
}
