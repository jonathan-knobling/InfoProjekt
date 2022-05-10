using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Actors.Enemies.EnemyAITest
{
    public class BoidsController : MonoBehaviour
    {
        [Header("")]
        [SerializeField] private ComputeShader computeShader;
        [SerializeField] private GameObject boidPrefab;
        [SerializeField] private Camera cam;

        [Header("Sim Data")]
        [SerializeField] private int boidsCount;
        [SerializeField] private float spawnRadius;
        [SerializeField] private float boidSpeed;
        [SerializeField] private float nearbyDis;
        private GameObject[] boidsGO;
        private Boid[] boidsData;
        private Vector2 targetPos;
        private int kernelHandle;

        private void Start()
        {
            boidsGO = new GameObject[boidsCount];
            boidsData = new Boid[boidsCount];
            kernelHandle = computeShader.FindKernel("CSMain");

            for (int i = 0; i < boidsCount; i++)
            {
                boidsData[i] = CreateBoid();
                boidsGO[i] = Instantiate(boidPrefab, boidsData[i].pos, Quaternion.Euler(boidsData[i].rot));
                boidsData[i].rot = boidsGO[i].transform.forward;
            }
        }

        private void Update()
        {
            targetPos = cam.ScreenToWorldPoint(Input.mousePosition);

            var buffer = new ComputeBuffer(boidsCount, 36);

            for (int i = 0; i < boidsCount; i++)
            {
                boidsData[i].flockPos = targetPos;
            }
            
            buffer.SetData(boidsData);
            
            computeShader.SetBuffer(kernelHandle, "boidBuffer", buffer);
            computeShader.SetFloat("deltaTime", Time.deltaTime);
            
            computeShader.Dispatch(kernelHandle, boidsCount, 1, 1);
            
            buffer.GetData(boidsData);
            
            buffer.Release();

            for (int i = 0; i < boidsCount; i++)
            {
                boidsGO[i].transform.localPosition = boidsData[i].pos;

                if (!boidsData[i].rot.Equals(Vector2.zero))
                {
                    boidsGO[i].transform.rotation = Quaternion.LookRotation(boidsData[i].rot);
                    boidsGO[i].transform.Rotate(0, -90f, 0);
                }
            }
        }

        private Boid CreateBoid()
        {
            var boid = new Boid();
            var pos = (Vector2) transform.position + Random.insideUnitCircle * spawnRadius;

            boid.pos = pos;
            boid.flockPos = cam.ScreenToWorldPoint(Input.mousePosition);
            boid.boidsCount = boidsCount;
            boid.nearbyDis = nearbyDis;
            boid.speed = boidSpeed;
            
            return boid;
        }
    }

    public struct Boid
    {
        public Vector2 pos;
        public Vector2 rot;
        public Vector2 flockPos;
        public float speed;
        public float nearbyDis;
        public float boidsCount;
    }
}