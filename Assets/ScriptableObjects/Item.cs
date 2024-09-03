using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Item : ScriptableObject {
    [SerializeField] public string description;
    [SerializeField] public int level;
    [SerializeField] public int maxLevel = 99;
    [SerializeField] public int goldCost;

    public override string ToString() {
        Match match = Regex.Match(name, @"(?<type>[A-Z][a-z]+)(?<name>([A-Z][a-z]+)+)");
        return match.Groups["name"].Value;
    }
}
