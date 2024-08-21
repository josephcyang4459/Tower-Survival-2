using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player")]
public class Player : ScriptableObject {
    [SerializeField] public int defaultIncome;
    [SerializeField] public int income;
    [SerializeField] public Sprite sprite;
}