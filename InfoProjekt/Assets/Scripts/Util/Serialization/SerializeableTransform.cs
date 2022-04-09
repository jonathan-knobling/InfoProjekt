using System;
using UnityEngine;

namespace Util.Serialization
{
    [Serializable]
    public class SerializeableTransform
    {
        public float[] position = new float[3];
        public float[] rotation = new float[4];
        public float[] scale = new float[3];
        
        public SerializeableTransform(Transform transform)
        {
            var localPosition = transform.localPosition;
            position[0] = localPosition.x;
            position[1] = localPosition.y;
            position[2] = localPosition.z;

            var localRotation = transform.localRotation;
            rotation[0] = localRotation.w;
            rotation[1] = localRotation.x;
            rotation[2] = localRotation.y;
            rotation[3] = localRotation.z;

            var localScale = transform.localScale;
            scale[0] = localScale.x;
            scale[1] = localScale.y;
            scale[2] = localScale.z;
        }

        public Vector3 GetPosition()
        {
            return new Vector3()
            {
                x = position[0],
                y = position[1],
                z = position[2]
            };
        }

        public Quaternion GetRotation()
        {
            return new Quaternion()
            {
                w = rotation[0],
                x = rotation[1],
                y = rotation[2],
                z = rotation[3]
            };
        }

        public Vector3 GetScale()
        {
            return new Vector3()
            {
                x = scale[0],
                y = scale[1],
                z = scale[2]
            };
        }
        
        public static void DeserializeTransform(SerializeableTransform serializeableTransform, Transform transform)
        {
            transform.localPosition = new Vector3(serializeableTransform.position[0], serializeableTransform.position[1], serializeableTransform.position[2]);
            transform.localRotation = new Quaternion(serializeableTransform.rotation[1], serializeableTransform.rotation[2], serializeableTransform.rotation[3], serializeableTransform.rotation[0]);
            transform.localScale = new Vector3(serializeableTransform.scale[0], serializeableTransform.scale[1], serializeableTransform.scale[2]);
        }
    }
}