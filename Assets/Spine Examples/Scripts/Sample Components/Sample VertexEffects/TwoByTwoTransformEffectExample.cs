using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Examples
{

    // This is a sample component for C# vertex effects for Spine rendering components.
    // Using shaders and materials to control vertex properties is still more performant
    // than using this API, but in cases where your vertex effect logic cannot be
    // expressed as shader code, these vertex effects can be useful.
    public class TwoByTwoTransformEffectExample : MonoBehaviour
    {

        public Vector2 xAxis = new Vector2(1, 0);
        public Vector2 yAxis = new Vector2(0, 1);

        SkeletonRenderer skeletonRenderer;

        void OnEnable()
        {
            skeletonRenderer = GetComponent<SkeletonRenderer>();
            if (skeletonRenderer == null) return;

            // Use the OnPostProcessVertices callback to modify the vertices at the correct time.
            skeletonRenderer.OnPostProcessVertices -= ProcessVertices;
            skeletonRenderer.OnPostProcessVertices += ProcessVertices;

            Debug.Log("2x2 Transform Effect Enabled.");
        }

        void ProcessVertices(MeshGeneratorBuffers buffers)
        {
            if (!this.enabled)
                return;

            int vertexCount = buffers.vertexCount; // For efficiency, limit your effect to the actual mesh vertex count using vertexCount

            // Modify vertex positions by accessing Vector3[] vertexBuffer
            Vector3[] vertices = buffers.vertexBuffer;
            Vector3 transformedPos = default(Vector3);
            for (int i = 0; i < vertexCount; i++)
            {
                Vector3 originalPos = vertices[i];
                transformedPos.x = (xAxis.x * originalPos.x) + (yAxis.x * originalPos.y);
                transformedPos.y = (xAxis.y * originalPos.x) + (yAxis.y * originalPos.y);
                vertices[i] = transformedPos;
            }

        }

        void OnDisable()
        {
            if (skeletonRenderer == null) return;
            skeletonRenderer.OnPostProcessVertices -= ProcessVertices;
            Debug.Log("2x2 Transform Effect Disabled.");
        }
    }

}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(Spine.Unity.Examples.TwoByTwoTransformEffectExample))]
public class TwoByTwoTransformEffectExampleEditor : UnityEditor.Editor
{

    Spine.Unity.Examples.TwoByTwoTransformEffectExample Target { get { return target as Spine.Unity.Examples.TwoByTwoTransformEffectExample; } }

    void OnSceneGUI()
    {
        Transform transform = Target.transform;
        LocalVectorHandle(ref Target.xAxis, transform, Color.red);
        LocalVectorHandle(ref Target.yAxis, transform, Color.green);
    }

    static void LocalVectorHandle(ref Vector2 v, Transform transform, Color color)
    {
        Color originalColor = UnityEditor.Handles.color;
        UnityEditor.Handles.color = color;
        UnityEditor.Handles.DrawLine(transform.position, transform.TransformPoint(v));
        v = transform.InverseTransformPoint(UnityEditor.Handles.PositionHandle(transform.TransformPoint(v), Quaternion.identity));
        UnityEditor.Handles.color = originalColor;
    }
}

#endif
