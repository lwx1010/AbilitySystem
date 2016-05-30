﻿public class AbilityPage_RequirementSection : ListSection<Ability> {

    public AbilityPage_RequirementSection(float spacing) : base(spacing) { }

    protected override string FoldOutLabel {
        get { return "Requriements"; }
    }

    protected override string ListRootName {
        get { return "requirements"; }
    }

    protected override SearchBox CreateSearchBox() {
        return new SearchBox(null, typeof(AbilityRequirement), AddListItem, "Add Requirement", "Requriements");
    }

}
//using System;
//using UnityEngine;
//using UnityEditor;
//using System.Collections.Generic;

//public class AbilityPage_RequirementSection : SectionBase<Ability> {

//    private bool shown;
//    private SearchBox searchBox;
//    private List<RenderData> renderData;
//    private SerializedPropertyX listRoot;

//    public class RenderData {
//        public bool isDisplayed;
//    }

//    public AbilityPage_RequirementSection(float spacing) : base(spacing) {
//        shown = true;
//        searchBox = new SearchBox(null, typeof(AbilityRequirement), AddRequirement, "Add Requirement", "Requirements");
//        renderData = new List<RenderData>();
//    }

//    public override void SetTargetObject(AssetItem<Ability> targetItem) {
//        base.SetTargetObject(targetItem);
//        listRoot = rootProperty.FindProperty("requirements");
//        int count = listRoot.ChildCount;
//        renderData = new List<RenderData>(count);
//        for (int i = 0; i < count; i++) {
//            RenderData data = new RenderData();
//            data.isDisplayed = false;
//            renderData.Add(data);
//        }
//    }

//    private void AddRequirement(Type type) {
//        AbilityRequirement requirement = Activator.CreateInstance(type) as AbilityRequirement;
//        RenderData data = new RenderData();
//        data.isDisplayed = true;
//        renderData.Add(data);
//        listRoot.ArraySize++;
//        listRoot.GetChildAt(listRoot.ArraySize - 1).Value = requirement;
//    }

//    private void RenderAbilityRequirement(SerializedPropertyX property, int index) {
//        AbilityRequirement requirement = property.Value as AbilityRequirement;
//        RenderData data = renderData[index];

//        EditorGUILayout.BeginVertical(EntitySystemWindow.CardStyle);
//        {//Render Foldout
//            EditorGUILayout.BeginHorizontal();
//            data.isDisplayed = EditorGUILayout.Foldout(data.isDisplayed, requirement.GetType().Name);
//            GUILayout.FlexibleSpace();

//            GUIStyle miniLeft = GUI.skin.GetStyle("minibuttonleft");
//            GUIStyle miniMid = GUI.skin.GetStyle("minibuttonmid");
//            GUIStyle miniRight = GUI.skin.GetStyle("minibuttonright");
//            if (GUILayout.Button("Delete", miniLeft)) {
//                listRoot.DeleteArrayElementAt(index);
//                renderData.RemoveAt(index);
//                return;
//            }
//            GUI.enabled = index != 0;
//            if (GUILayout.Button("Up", miniMid)) {
//                Swap(index, -1);
//            }
//            GUI.enabled = index != listRoot.ChildCount - 1;
//            if (GUILayout.Button("Down", miniRight)) {
//                Swap(index, 1);
//            }

//            GUI.enabled = true;
//            EditorGUILayout.EndHorizontal();
//        }
//        if (data.isDisplayed) {

//            DrawerUtil.PushLabelWidth(125);

//            { //Render Children
//                EditorGUI.indentLevel++;
//                for (int i = 0; i < property.ChildCount; i++) {
//                    SerializedPropertyX child = property.GetChildAt(i);
//                    EditorGUILayoutX.PropertyField(child, child.label, child.isExpanded);
//                    GUILayout.Space(5f);
//                }
//                EditorGUI.indentLevel--;
//            }

//            DrawerUtil.PopLabelWidth();
//        }
//        EditorGUILayout.EndVertical();
//    }

//    private void Swap(int index, int directon) {
//        directon = Mathf.Clamp(directon, -1, 1);
//        listRoot.SwapArrayElements(index, directon);
//        var tempData = renderData[index];
//        renderData[index] = renderData[index + directon];
//        renderData[index + directon] = tempData;
//    }

//    public override void Render() {
//        if (targetItem == null) return;

//        shown = EditorGUILayout.Foldout(shown, "Requirements");

//        if (shown) {
//            EditorGUI.indentLevel++;
//            for (int i = 0; i < listRoot.ChildCount; i++) {
//                SerializedPropertyX child = listRoot.GetChildAt(i);
//                RenderAbilityRequirement(child, i);
//                GUILayout.Space(5);
//            }
//            EditorGUI.indentLevel--;
//            GUILayout.Space(20f);
//            EditorGUILayout.BeginHorizontal();
//            GUILayout.FlexibleSpace();
//            searchBox.Render();
//            GUILayout.FlexibleSpace();
//            EditorGUILayout.EndHorizontal();
//        }
//    }
//}