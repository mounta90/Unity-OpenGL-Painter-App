using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{

    //  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    //  (1) ORGANIC LINE.
    //  Draw a line with mouse input. When clicking down, the mouse must continuously draw until the mouse button is lifted. 
    //  Hint: You will not need to store ALL points, only the previous point. 
    //  Also, do not clear the screen.
    //  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    internal class OrganicLine
    {
        public void Draw(float size, Color color, float startingX, float startingY, float endingX, float endingY)
        {
            GL.PushMatrix();


            float offset = size / 2;

            GL.Begin(GL.LINES);

            GL.Color(color);

            Vector3 startingVector = new Vector3(startingX, startingY, 0);
            Vector3 endingVector = new Vector3(endingX, endingY, 0);

            GL.Vertex(startingVector);
            GL.Vertex(endingVector);

            GL.End();

            GL.PopMatrix();
        }
    }
}
