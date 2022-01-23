using System;

namespace ProjectileMotion
{
    public static class ProjectileMotion
    {
        public static void Main()
        {
            LevelOne();
            //LevelTwo();
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
            double vz = Math.Sin(theta) * initialV; ;
            double speed = v;
            double ax = 0;
            double ay = 0;
            double az = 0;
            double magnitudeAcc = 0;
            double time = 0;
            double t = 0.02;
            double theta = Math.PI/4;

            //level two
            double particleMass = 4; //kg
            double C = 0.5; //kg/m
            double forceGrav;
            double forceAir;
            double newAccel;

            Console.WriteLine("time + \t + x + \t + y + \t + z + \t + dist + \t + vx + \t + vy + \t + vz + \t + ax + \t + ay + \t + az + \t + magnitudeAcc + \t + speed");

            while (z >= 0)
            {
                x = initialV * time * Math.Cos(theta);
                y = 0;
                z = (initialV * time * Math.Sin(theta)) - Math.Sign(g) * (0.5 * g * Math.Pow(time, 2));
                
                dist = x;

                //level two shit
                forceAir = C * (v * v);
                forceGrav = particleMass * g;
                ax = (-1 * forceAir * Math.Sign(v) + forceGrav) / particleMass;

                //vx = Math.Cos(theta)*initialV;
                vz = Math.Sin(theta)* initialV - (time * g * Math.Sign(g)); //initial v component - gravity as time goes on
                vy = 0;
                v = Math.Sqrt(Math.Pow(vx, 2) + Math.Pow(vz, 2) + Math.Pow(vy, 2));

                //level two shit
                vx = vx + (ax * t);


                ax = 0;
                az = g;
                ay = 0;

                speed = v;
                magnitudeAcc = az;

                time += t;

                if (z >= 0)
                {
                    Console.WriteLine(time + "\t" + x + "\t" + y + "\t" + z + "\t" + dist + "\t" + vx + "\t" + vy + "\t" + vz + "\t" + ax + "\t" + ay + "\t" + az + "\t" + magnitudeAcc + "\t" + speed);
                }
            }
        }

        public static void LevelTwo()
        {

         


        }
    }
}