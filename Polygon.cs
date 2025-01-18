using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets
{

    // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    // (5) POLYGON.
    // Draw a polygon of a custom 2D shape and parameterize it.
    // Add a stamp tool to stamp your custom shape at a specified position and rotation (position can be determined by the mouse, and rotation can be determined using a variable).
    // Right click the mouse and it draws your custom shape. Hint: Use translate.
    // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    internal class Polygon
    {

        public void Draw(float mousePositionX, float mousePositionY)
        {
            GL.PushMatrix();


            Color darkGreen = new Color(0f, 50f / 255, 32f / 255, 1f);

            GL.Begin(GL.TRIANGLES);
            GL.Color(darkGreen);

            float[] quadLengths = new float[3] { 0.05f, 0.075f, 0.1f };

            int i = (int)QuadSize.Small;
            float offset = quadLengths[i] / 2;

            GL.Vertex3(mousePositionX, mousePositionY + (offset * 0.8f), 0); // V1
            GL.Vertex3(mousePositionX + offset, mousePositionY - (offset * 0.2f), 0); // V2
            GL.Vertex3(mousePositionX - offset, mousePositionY - (offset * 0.2f), 0); // V3
            GL.Vertex3(mousePositionX, mousePositionY + (offset * 0.8f), 0); // V4

            GL.End();

            // #############################################################

            GL.Begin(GL.TRIANGLES);
            GL.Color(darkGreen);

            GL.Vertex3(mousePositionX, mousePositionY, 0); // V1
            GL.Vertex3(mousePositionX + offset, mousePositionY - offset, 0); // V2
            GL.Vertex3(mousePositionX - offset, mousePositionY - offset, 0); // V3
            GL.Vertex3(mousePositionX, mousePositionY, 0); // V4

            GL.End();

            // #############################################################

            GL.Begin(GL.QUADS);

            Color brown = new Color(88f / 255, 57f / 255, 39f / 255, 1f);
            GL.Color(brown);

            int offsetFactor = 3;

            GL.Vertex3(mousePositionX - (offset / offsetFactor), mousePositionY - offset, 0); // V1
            GL.Vertex3(mousePositionX + (offset / offsetFactor), mousePositionY - offset, 0); // V2
            GL.Vertex3(mousePositionX + (offset / offsetFactor), mousePositionY - (offset * offsetFactor), 0); // V3
            GL.Vertex3(mousePositionX - (offset / offsetFactor), mousePositionY - (offset * offsetFactor), 0); // V4

            GL.End();

            // #############################################################

            GL.PopMatrix();
        }
    }
}
