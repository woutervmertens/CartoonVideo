using System;

/// <summary>
/// Calculations to find closest point in 3D space by Liam Baillie
/// Picked what needed from original project on github: https://github.com/LiamBaillie/FindingClosestPointInThreeSpace
/// </summary>
namespace CartoonVideo.ViewModel
{
    class ClosestPointFinder
    {
        /// <summary>
        /// Hopefully faster method for accomplishing same goal
        /// </summary>
        /// <param name="source">Constant point to check against</param>
        /// <param name="points">Array of points to check against</param>
        /// <returns>Closest Point to source</returns>
        private Vector3 getClosestPointFromArray_Fast(Vector3 source, Vector3[] points)
        {
            double sum = Double.MaxValue;
            double temp;

            Vector3 bestVector = new Vector3(0, 0, 0);
            double bestDistance = Double.MaxValue;


            //For every other Vector3 - Find smallest vector sum
            for (int i = 0; i < points.Length; i++)
            {
                temp = Math.Abs(points[i].x) + Math.Abs(points[i].y) + Math.Abs(points[i].z);
                if (temp < sum)
                {
                    sum = temp;
                }
            }


            //Take the new check volume and find closest Vector3
            for (int i = 0; i < points.Length; i++)
            {
                if (Math.Abs(points[i].x) <= sum && Math.Abs(points[i].y) <= sum && Math.Abs(points[i].z) <= sum)
                {
                    temp = getPythagorasDistance(source, points[i]);
                    if (temp < bestDistance)
                    {
                        bestVector = points[i];
                        bestDistance = temp;
                    }
                }
            }

            return bestVector;
        }

        /// <summary>
        /// Given a source point and an array of vectors, the method returns the Vector3 closest to the source
        /// </summary>
        /// <param name="source">Constant Vector3 to be checked against</param>
        /// <param name="points">Array of Vector3 to check against for distance</param>
        /// <returns>Closest Vector3 to source</returns>
        private Vector3 getClosestPointFromArray_Brute(Vector3 source, Vector3[] points)
        {
            Vector3 bestVector = new Vector3(Double.MaxValue, Double.MaxValue, Double.MaxValue);
            double bestDistance = Double.MaxValue;

            for (int i = 0; i < points.Length; i++)
            {
                double current = getPythagorasDistance(source, points[i]);
                if (current < bestDistance)
                {
                    bestVector = points[i]; bestDistance = current;
                }
            }

            return bestVector;
        }

        /// <summary>
        /// Calculate Distance between two vectors in 3-space using Pythagoras' Theorum
        /// </summary>
        /// <param name="start">Starting Vector</param>
        /// <param name="end">Ending Vector</param>
        /// <returns>Distance between two vectors</returns>
        private double getPythagorasDistance(Vector3 start, Vector3 end)
        {
            return Math.Sqrt(Math.Pow((end.x - start.x), 2) + Math.Pow((end.y - start.y), 2) + Math.Pow((end.z - start.z), 2));
        }
    }

    /// <summary>
    /// Simple Vector for 3-Space
    /// </summary>
    public struct Vector3
    {
        public double x, y, z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    }
