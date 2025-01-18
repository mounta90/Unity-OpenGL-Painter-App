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
    // (3) ERASE. 
    // Additionally, a user should be able to erase(using a quad) with the mouse.
    // Hint: If there is no “erase” drawing tool, how might you achieve this otherwise?
    // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    internal class QuadErase
    {
        public void Draw(float size, float mousePositionX, float mousePositionY)
        {
            Color color = Color.black;

            QuadBrush quadBrush = new QuadBrush();
            quadBrush.Draw(size, size, color, mousePositionX, mousePositionY);
        }
    }
}
