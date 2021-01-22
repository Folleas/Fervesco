using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern {
    private List<PatternDirection> _fragments = new List<PatternDirection>();
    public List<PatternDirection> fragments {
        get {
            return _fragments;
        }
        set {
            _fragments = value;
        }
    }
    public void AddDirection(PatternDirection direction) {
        _fragments.Add(direction);
    }
    public static bool operator ==(Pattern a, Pattern b) {
        bool status = true;

        if (a.fragments.Count == b.fragments.Count) {
            for (int i = 0; i != a.fragments.Count; i++) {
                if (a.fragments[i] != b.fragments[i]) {
                    status = false;
                    break;
                }
            }
        }
        else
            status = false;
        return status;
    }
    public static bool operator !=(Pattern a, Pattern b) {
        return a._fragments != b._fragments;
    }
    public override bool Equals(object o) {
        return this == o as Pattern;
    }
    public override int GetHashCode() {
        return 0;
    }
}