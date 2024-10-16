using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class StoreItem : MonoBehaviour {
    [Header("These are all references for auto-text-generation during game")]
    [SerializeField] public TMP_Text itemName;
    [SerializeField] public TMP_Text goldCost;
    [SerializeField] public TMP_Text itemDescriptionText;
    [SerializeField] public GameObject details;

    [Header("Except for this one, this one is used for item visibility")]
    [SerializeField] public CanvasGroup descriptionCanvasGroup;

    [Header("Prefabs used for item description creation OnPointerEnter")]
    [SerializeField] GameObject emptyDetailsPrefab;
    [SerializeField] GameObject itemDetailPrefab;
    [SerializeField] GameObject bottomFiller;

    public void ChangeDescriptionCanvasGroupAlpha(float alpha) { descriptionCanvasGroup.alpha = alpha; }

    public void ChangeOnHoverItemDescription(Item item) {
        DetailsReset();
        itemName.text = item.ToString();
        goldCost.text = item.goldCost.ToString();

        if (item.GetType() == typeof(Weapon)) {
            Weapon tempItem = (Weapon) item;
            itemDescriptionText.text = "";

            CreateItemDetail("DAMAGE:", tempItem.damage.ToString());
            CreateItemDetail("DAMAGE TYPE:", tempItem.damageType.ToString());
            CreateItemDetail("RANGE:", tempItem.range.ToString());
        }
        else if (item.GetType() == typeof(Buff)) {
            Buff tempItem = (Buff) item;
            itemDescriptionText.text = item.description;

            CreateItemDetail("FLAT INCREASE:", tempItem.flatRate.ToString());
            CreateItemDetail("PERCENT INCREASE:", tempItem.percentRate.ToString());
        }
        else {
            itemDescriptionText.text = item.description;
        }

        CreateNonDetail(bottomFiller);
    }

    private void CreateItemDetail(string detailType, string detailAmount) {
        GameObject itemDetail = Instantiate(itemDetailPrefab);
        itemDetail.transform.GetChild(0).GetComponent<TMP_Text>().text = detailType;
        itemDetail.transform.GetChild(1).GetComponent<TMP_Text>().text = detailAmount.ToString();
        itemDetail.transform.SetParent(details.transform);
    }

    private void CreateNonDetail(GameObject prefab) {
        GameObject itemDivider = Instantiate(prefab);
        itemDivider.transform.SetParent(details.transform);
    }

    private void DetailsReset() {
        Transform parent = details.transform.parent;
        Destroy(details);
        details = Instantiate(emptyDetailsPrefab);
        details.transform.SetParent(parent);
    }
}
