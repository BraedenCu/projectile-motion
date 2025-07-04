﻿using System;

namespace ProjectileMotion
{
    public static class ProjectileMotion
    {
        public static void Main()
        {
            //LevelOne();
            plotMotion(5, 45);
            //LevelTwo();
        }

        public static void plotMotion(double initialVelocity, double angle)
        {
            double g = -9.8;
            double ax=0, ay=0, az=0, magacc=0;
            double theta = angle;
            double vx = Math.Cos(theta) * initialVelocity, vy=0, vz=Math.Sin(theta) * initialVelocity;
            double x=0, y=0, z=0;
            double time = 0;
            double t = 0.01;
            double speed = 0, distance = 0;

            double mass = 4; //kg
            double C = 0.5; //kg/m
            double forceGrav, forceAir, newAccel, netForce;


            for (time = 0; z >= 0; time+=t) 
            {
                Console.WriteLine(time + "\t" + x + "\t" + y + "\t" + z + "\t" + distance + "\t" + vx + "\t" + vy + "\t" + vz + "\t" + speed + "\t" + ax + "\t" + ay + "\t" + az + "\t" + magacc);

                speed = Math.Sqrt(vx * vx + vy * vy + vz * vz);
                //for air res
                double xGrav = 0;
                double zGrav = -9.8;
                
                ax = (xGrav * mass - C * speed * vx) / mass;
                ay = 0;
                az = (zGrav * mass - C * speed * vz) / mass;

                //not for air res
                //ax = 0;
                //ay = 0;
                //az = g;
                magacc = Math.Sqrt(ax * ax + ay * ay + az * az);
                vx = vx + ax * t;
                vy = vy + ay * t;
                vz = vz + az * t;
                speed = Math.Sqrt(vx*vx + vy*vy + vz*vz);
                x = x + vx * t;
                y = y + vy * t;
                z = z + vz * t;
                distance = Math.Sqrt(x * x + y * y + z * z);
            }
        }

        public static void LevelOne()
        {
            double initialV = 5;
            double v = initialV;
            double g = -9.8;
            double y = 0;
            double x = 0;
            double z = 0;
            double dist = 0;
            double theta = Math.PI / 4;
            double vx = Math.Cos(theta) * initialV;
            double vy = 0;
            double vz = Math.Sin(theta) * initialV;
            double speed = v;
            double ax = 0;
            double ay = 0;
            double az = 0;
            double magnitudeAcc = 0;
            double time = 0;
            double t = 0.02;

            while (z >= 0)
            {
                x = initialV * time * Math.Cos(theta); //magnitude of the horizontal component
                y = 0;
                z = (initialV * time * Math.Sin(theta)) - Math.Sign(g) * (0.5 * g * Math.Pow(time, 2)); //magnitude of vertical component - velocity due to accel due to gravity

                dist = x;

                vx = Math.Cos(theta) * initialV;
                vz = Math.Sin(theta) * initialV - (time * g * Math.Sign(g)); //initial v component - gravity as time goes on
                vy = 0;

                ax = 0;
                az = g;
                ay = 0;

                speed = Math.Sqrt(Math.Pow(vx, 2) + Math.Pow(vz, 2) + Math.Pow(vy, 2));
                magnitudeAcc = Math.Sqrt(Math.Pow(ax, 2) + Math.Pow(az, 2) + Math.Pow(ay, 2));

                time += t;

                if (z >= 0)
                {
                    Console.WriteLine(time + "\t" + x + "\t" + y + "\t" + z + "\t" + dist + "\t" + vx + "\t" + vy + "\t" + vz + "\t" + ax + "\t" + ay + "\t" + az + "\t" + magnitudeAcc + "\t" + speed);
                }
            }
        }

        public static void LevelTwo()
        {
            double initialV = 5;
            double v = initialV;
            double g = -9.8;
            double y = 0;
            double x = 0;
            double z = 0;
            double dist = 0;
            double theta = Math.PI / 4;
            double vx = Math.Cos(theta) * initialV;
            double vy = 0;
            double vz = Math.Sin(theta) * initialV;
            double speed = v;
            double ax = 0;
            double ay = 0;
            double az = 0;
            double av = 0; //acceleration of magnitude vector
            double magnitudeAcc = 0;
            double time = 0;
            double t = 0.01;

            //level two
            double particleMass = 4; //kg
            double C = 0.5; //kg/m
            double forceGrav;
            double forceAir;
            double newAccel;
            double netForce;

            //Console.WriteLine("time + \t + x + \t + y + \t + z + \t + dist + \t + vx + \t + vy + \t + vz + \t + ax + \t + ay + \t + az + \t + magnitudeAcc + \t + speed");
            while (z >= 0)
            {
                //v = Math.Sqrt(Math.Pow(vx, 2) + Math.Pow(vz, 2) + Math.Pow(vy, 2));
                newAccel = (C / particleMass) * (v * v) * Math.Sign(v) * -1;
                av = newAccel;
                v = v + (newAccel * t);

                vx = Math.Cos(theta) * v;
                vz = Math.Sin(theta) * v - (time * g * Math.Sign(g)); //initial v component - gravity as time goes on
                vy = 0;

                //Console.WriteLine(newAccel + "\t" + v);

                x = x + vx * t;
                y = y + vy * t;
                z = z + vz * t;

                dist = x;

                ax = 0;
                az = g;
                ay = 0;

                speed = Math.Sqrt(Math.Pow(vx, 2) + Math.Pow(vz, 2) + Math.Pow(vy, 2));
                magnitudeAcc = av * Math.Sign(av);

                time += t;

                if (z >= 0)
                {
                    Console.WriteLine(time + "\t" + x + "\t" + y + "\t" + z + "\t" + dist + "\t" + vx + "\t" + vy + "\t" + vz + "\t" + ax + "\t" + ay + "\t" + az + "\t" + magnitudeAcc + "\t" + speed);
                }
            }
        }
    }
}