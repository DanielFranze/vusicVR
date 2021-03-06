﻿using UnityEngine;
using System.Collections;
using System.Linq;


    public class movePointSensor : MonoBehaviour
    {
        private float speed;




        public float getSpeed()
        {
            return speed;
        }

        public void setSpeed(float value)
        {
            speed = value;
        }

        public void subSpeed(float value)
        {
            speed -= value;
        }

        public void addSpeed(float value)
        {
            speed += value;
        }


        private Transform[] sensorPoints;
        private int currentPoint;

        // Use this for initialization
        void Start()
        {
            // Global
            speed = 2.5f;


            // Lokal
            sensorPoints = new Transform[32];
            foreach (int index in Enumerable.Range(0, 32))
            {
                sensorPoints[index] = GameObject.Find("rod_"+ index + "_body").transform;
            }
            transform.position = sensorPoints[0].position;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position == sensorPoints[currentPoint].position)
            {
                currentPoint++;
            }

            if (currentPoint >= sensorPoints.Length)
            {
                currentPoint = 0;
            }

            transform.position = Vector3.MoveTowards(transform.position, sensorPoints[currentPoint]
                                                     .position, speed * Time.deltaTime);
        }
    }
