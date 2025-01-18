using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{

    // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    // (2) BRUSH & COLOR.
    // Draw with a quad and be able to change size of brush (at least 3 sizes) and color of brush (at least 3 different colors)
    // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    internal class QuadBrush
    {
        public void Draw(float height, float width, Color color, float mousePositionX, float mousePositionY)
        {

            GL.PushMatrix();

            GL.Begin(GL.QUADS);
            GL.Color(color);

            float widthOffset = width / 2;
            float heightOffset = height / 2;

            GL.Vertex3(mousePositionX - widthOffset, mousePositionY - heightOffset, 0);
            GL.Vertex3(mousePositionX + widthOffset, mousePositionY - heightOffset, 0);
            GL.Vertex3(mousePositionX + widthOffset, mousePositionY + heightOffset, 0);
            GL.Vertex3(mousePositionX - widthOffset, mousePositionY + heightOffset, 0);
            
            GL.End();

            GL.PopMatrix();
        }
    }
}
