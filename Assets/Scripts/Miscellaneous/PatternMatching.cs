using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternMatching {
    static Vector2Int FindPosition(Grid model, int value) {
        Vector2Int position = new Vector2Int(-1, -1);
        for (int i = 0; i != model.dimension.y; i++) {
            for (int j = 0; j != model.dimension.x; j++) {
                if (model.GetValue(j, i) == value) {
                    position.x = j;
                    position.y = i;
                }
            }
        }
        return position;
    }

    static PatternDirection FindDirection(Grid model, Vector2Int currentPosition) {
        int currentValue = model.GetValue(currentPosition.x, currentPosition.y);

        foreach(PatternDirection patternDirection in PatternDirection.GetValues(typeof(PatternDirection))) {
            switch (patternDirection) {
                case PatternDirection.Up :
                    if (model.GetValue(currentPosition.x, currentPosition.y - 1) == currentValue + 1)
                        return PatternDirection.Up;
                    break;
                case PatternDirection.Down :
                    if (model.GetValue(currentPosition.x, currentPosition.y + 1) == currentValue + 1)
                        return PatternDirection.Down;
                    break;
                case PatternDirection.Left :
                    if (model.GetValue(currentPosition.x - 1, currentPosition.y) == currentValue + 1)
                        return PatternDirection.Left;
                    break;
                case PatternDirection.Right :
                    if (model.GetValue(currentPosition.x + 1, currentPosition.y) == currentValue + 1)
                        return PatternDirection.Right;
                    break;
            }
        }
        return PatternDirection.Undefined;
    }

    static Pattern CreatePattern(Grid model) {
        Vector2Int endPosition = new Vector2Int(-1, -1);
        Pattern pattern = new Pattern();
        Vector2Int position = FindPosition(model, 1);
        PatternDirection actualDirection = FindDirection(model, position);
        PatternDirection direction;

        pattern.AddDirection(actualDirection);
        while (position != endPosition) {
            if ((direction = FindDirection(model, position)) == PatternDirection.Undefined)
                break;
            if (actualDirection != direction) {
                pattern.AddDirection(direction);
            }
            actualDirection = direction;
            position = FindPosition(model, model.GetValue(position.x, position.y) + 1);
        }
        foreach (PatternDirection p in pattern.fragments)
            Debug.Log(p);
        return pattern;
    }

    static public bool MatchPattern(Grid source, Grid model) {
        return CreatePattern(source) == CreatePattern(model);
    }
}
