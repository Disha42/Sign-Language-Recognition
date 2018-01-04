﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Kinect;
using System;
using System.Text;

namespace KinectSimpleGesture
{

    /// <summary>
    /// Represents a single gesture segment which uses relative positioning of body parts to detect a gesture.
    /// </summary>
    public interface WhatGestureSegment
    {
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        GesturePartResult whatUpdate(Skeleton skeleton);
    }

    /* public static class Globals
     {
         public static float depth1 = 0.00f;
         public static float depth2 = 0.00f;
     }*/
    public class WhatSegment1 : WhatGestureSegment
    {

        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        public GesturePartResult whatUpdate(Skeleton skeleton)
        {
            // Hand above elbow
            if ((skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.WristRight].Position.Z) && (skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.WristLeft].Position.Z) && (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y) && (skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y) && ((skeleton.Joints[JointType.HandRight].Position.X - skeleton.Joints[JointType.HandLeft].Position.X)>0.5) )
            {
            
                
               
                    
                   // if ((skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y) && (skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y) )
                    //Globals.depth1 = skeleton.Joints[JointType.HandRight].Position.Z;
                    //{
                       
                       

                            return GesturePartResult.Succeeded;
            
                        
                    
                
            }

            // Hand dropped
            return GesturePartResult.Failed;
        }
    }

    public class WhatSegment2 : WhatGestureSegment
    {
        //public float depth2;
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        public GesturePartResult whatUpdate(Skeleton skeleton)
        {
            // Hand above elbow
            if ((skeleton.Joints[JointType.Head].Position.Y > skeleton.Joints[JointType.HandRight].Position.Y) && (skeleton.Joints[JointType.Spine].Position.Y < skeleton.Joints[JointType.HandRight].Position.Y) && (skeleton.Joints[JointType.ShoulderLeft].Position.X < skeleton.Joints[JointType.HandRight].Position.X) && (skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X))
            {
                if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y)
                {

                    // Hand left of elbow
                    //Globals.depth2 = skeleton.Joints[JointType.HandRight].Position.Z;
                    //Console.WriteLine("depth2..here..." + Globals.depth2);
                    return GesturePartResult.Succeeded;
                }
            }
            // Hand dropped
            return GesturePartResult.Failed;
        }
    }
    /*public class compare_depth: ThankuGestureSegment
    {
        public GesturePartResult thankuUpdate(Skeleton skeleton)
        {
       if(Globals.depth1>Globals.depth2)
       {
           return GesturePartResult.Succeeded;
       }
       return GesturePartResult.Failed;

       }
    }*/
}