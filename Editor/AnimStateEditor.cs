using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace GX.MotorSystem
{

    public class AnimStateEditor : Editor
    {
        bool show;

        [CustomEditor(typeof(AnimState))]
        public override void OnInspectorGUI()
        {
            //AnimState myTarget = (AnimState)target;

            //if (show = EditorGUILayout.Foldout(show, "Conditions"))
            //{
            //    foreach (Anim a in myTarget.conditions)
            //    {
            //        a.show = EditorGUILayout.Foldout(a.show, a.paramName);
            //        if (a.show)
            //        {
            //            switch (a.Var)
            //            {
            //                case (Anim.VarType.Bool): a.Boolean = EditorGUILayout.Toggle(a.Boolean); break;
            //                case (Anim.VarType.Int): a.Integer = EditorGUILayout.IntField(a.Integer); break;
            //                case (Anim.VarType.Float): a.Float = EditorGUILayout.FloatField(a.Float); break;

            //            }
            //        }
            //    }
            //}
        }
    }
}
