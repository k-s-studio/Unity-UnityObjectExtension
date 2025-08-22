using UnityEngine;

namespace Assets.KsCode.UnityObjectExtension {
    public static class ChildExtension {
        public static T NewChild<T, T_parent>(this T_parent parent, T objRef) where T_parent : Component where T : Component {
            T child = objRef;
            child.transform.SetParent(parent.transform);
            return child;
        }
        public static GameObject NewChild<T_parent>(this T_parent parent, string name)
            where T_parent : Component => parent.transform.NewChild(new GameObject(name));

        public static GameObject NewChild(this Transform parent, GameObject objRef) {
            GameObject child = objRef;
            child.transform.parent = parent;
            return child;
        }

        public static void DestroyAllChild<T>(this T gameObject) where T : Component => gameObject.transform.DestroyAllChild();
        public static void DestroyAllChild(this Transform transform) {
            while (transform.childCount > 0)
                GameObject.DestroyImmediate(transform.GetChild(0).gameObject);
            // foreach (Transform child in transform) DestroyImmediate(child.gameObject); 
            // 造成隔一個刪不掉，因為transform中刪掉child向前遞補，同時索引值仍往後移
        }
    }
}