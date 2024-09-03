using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour {
    [Header("These are all references for auto-text-generation during game")]
    [SerializeField] public TMP_Text itemName;
    [SerializeField] public TMP_Text itemLevel;
    [SerializeField] public TMP_Text goldCost;
    [SerializeField] public TMP_Text itemDescriptionText;
    [SerializeField] public CanvasGroup itemDescriptionCanvasGroup;
    [SerializeField] public GameObject details;

    [Header("Prefabs used for item description OnPointerEnter")]
    [SerializeField] GameObject emptyDetailsPrefab;
    [SerializeField] GameObject itemDetailPrefab;
    [SerializeField] GameObject bottomFiller;

    public void ChangeCanvasGroupAlpha(float alpha) { itemDescriptionCanvasGroup.alpha = alpha; }

    public void ChangeOnHoverItemDescription(Weapon weapon) {
        DetailsReset();
        itemName.text = weapon.ToString();
        goldCost.text = weapon.goldCost.ToString();
        itemDescriptionText.text = "";

        CreateItemDetail("DAMAGE:", weapon.damage.ToString());
        CreateItemDetail("DAMAGE TYPE:", weapon.damageType.ToString());
        CreateItemDetail("RANGE:", weapon.range.ToString());
        CreateNonDetail(bottomFiller);
    }

    public void ChangeOnHoverItemDescription(Buff buff) {
        DetailsReset();
        itemName.text = buff.ToString();
        goldCost.text = buff.goldCost.ToString();
        itemDescriptionText.text = buff.description;

        CreateItemDetail("FLAT INCREASE:", buff.flatRate.ToString());
        CreateItemDetail("PERCENT INCREASE:", buff.percentRate.ToString());
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
