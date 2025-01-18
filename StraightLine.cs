using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{

    // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    // (4) STRAIGHT LINE
    // Add a feature that will draw a straight line given two points...
    // click down and line forms, but only is released when the button is released.
    // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    internal class StraightLine
    {

        public void Draw(Color color, float startingX, float startingY, float endingX, float endingY)
        {
            GL.PushMatrix();

            GL.Begin(GL.LINES);

            GL.Color(color);

            Vector3 startingLinePoint = new Vector3(startingX, startingY, 0);
            GL.Vertex(startingLinePoint);

            Vector3 endingLinePoint = new Vector3(endingX, endingY, 0);
            GL.Vertex(endingLinePoint);

            GL.End();

            GL.PopMatrix();

        }
    }
}
