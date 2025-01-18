using System;
using UnityEngine;

namespace Assets
{

    // Quad Brush Sizes
    enum QuadSize : int
    {
        Small = 0,
        Medium = 1,
        Large = 2
    };

    // Painter Modes
    enum PainterMode : int
    {
        OrganicLine = 0,
        QuadBrush = 1,
        QuadErase = 2,
        StraightLine = 3,
        Polygon = 4
    }

    internal class Toolbox
    {
        private Color currentPainterColor;
        private int currentPainterSize;
        private int currentPainterMode;

        // Create a class constructor with a parameter
        public Toolbox(Color painterColor, int painterMode, int painterSize)
        {
            currentPainterColor = painterColor;
            currentPainterMode = painterMode;
            currentPainterSize = painterSize;
        }

        public (int, int, Color) DrawToolboxAndReturnPainterMode(float toolboxWidth, float toolboxHeight, float[] sizes, float mousePositionX, float mousePositionY)
        {
            // -----------------------------------------------
            // Toolbox Background
            // -----------------------------------------------
            GL.PushMatrix();
            GL.Begin(GL.QUADS);

            Color toolboxBackground = Color.white;
            GL.Color(toolboxBackground);

            GL.Vertex3(0, 0, 0);
            GL.Vertex3(toolboxWidth, 0, 0);
            GL.Vertex3(toolboxWidth, toolboxHeight, 0);
            GL.Vertex3(0, toolboxHeight, 0);

            GL.End();
            GL.PopMatrix();
            // -----------------------------------------------
            // -----------------------------------------------
            Color toolColor = Color.black;
            // -----------------------------------------------
            // -----------------------------------------------
            // Toolbox Organic Line
            // -----------------------------------------------
            float circleDiameter = 0.03f;
            float circleCenterX = 0.1f;
            float circleCenterY = 0.9f;

            Color organicLineSelectorBackgroundColor = Color.gray;
            DrawQuad(circleDiameter, organicLineSelectorBackgroundColor, circleCenterX, circleCenterY);

            DrawCircle(circleDiameter, toolColor, circleCenterX, circleCenterY);


            float leftButtonEdge = circleCenterX - (circleDiameter / 2);
            float rightButtonEdge = circleCenterX + (circleDiameter / 2);
            bool horizontalCondition = mousePositionX > leftButtonEdge && mousePositionX < rightButtonEdge;

            float bottomButtonEdge = circleCenterY - (circleDiameter / 2);
            float topButtonEdge = circleCenterY + (circleDiameter / 2);
            bool verticalCondition = mousePositionY > bottomButtonEdge && mousePositionY < topButtonEdge;

            bool isOrganicLineClicked = horizontalCondition && verticalCondition;
            // -----------------------------------------------
            // -----------------------------------------------
            // Toolbox Quad Brushes
            // -----------------------------------------------
            float centerY = 0.75f;
            
            float sqCenterX = 0.06f;
            float smallSize = sizes[(int)QuadSize.Small];

            DrawQuad(smallSize, toolColor, sqCenterX, centerY);

            float sqLeftButtonEdge = sqCenterX - (smallSize / 2);
            float sqRightButtonEdge = sqCenterX + (smallSize / 2);
            bool sqHorizontalCondition = mousePositionX > sqLeftButtonEdge && mousePositionX < sqRightButtonEdge;

            float sqBottomButtonEdge = centerY - (smallSize / 2);
            float sqTopButtonEdge = centerY + (smallSize / 2);
            bool sqVerticalCondition = mousePositionY > sqBottomButtonEdge && mousePositionY < sqTopButtonEdge;

            bool isSmallQuadClicked = sqHorizontalCondition && sqVerticalCondition;




            float mqCenterX = 0.1f;
            float mediumSize = sizes[(int)QuadSize.Medium];

            DrawQuad(mediumSize, toolColor, mqCenterX, centerY);

            float mqLeftButtonEdge = mqCenterX - (mediumSize / 2);
            float mqRightButtonEdge = mqCenterX + (mediumSize / 2);
            bool mqHorizontalCondition = mousePositionX > mqLeftButtonEdge && mousePositionX < mqRightButtonEdge;

            float mqBottomButtonEdge = centerY - (mediumSize / 2);
            float mqTopButtonEdge = centerY + (mediumSize / 2);
            bool mqVerticalCondition = mousePositionY > mqBottomButtonEdge && mousePositionY < mqTopButtonEdge;

            bool isMediumQuadClicked = mqHorizontalCondition && mqVerticalCondition;




            float lqCenterX = 0.15f;
            float largeSize = sizes[(int)QuadSize.Large];

            DrawQuad(largeSize, toolColor, lqCenterX, centerY);

            float lqLeftButtonEdge = lqCenterX - (largeSize / 2);
            float lqRightButtonEdge = lqCenterX + (largeSize / 2);
            bool lqHorizontalCondition = mousePositionX > lqLeftButtonEdge && mousePositionX < lqRightButtonEdge;

            float lqBottomButtonEdge = centerY - (largeSize / 2);
            float lqTopButtonEdge = centerY + (largeSize / 2);
            bool lqVerticalCondition = mousePositionY > lqBottomButtonEdge && mousePositionY < lqTopButtonEdge;

            bool isLargeQuadClicked = lqHorizontalCondition && lqVerticalCondition;

            // -----------------------------------------------
            // -----------------------------------------------
            // Toolbox Quad Eraser
            // -----------------------------------------------
            Color eraserColor = new Color(255f / 255, 182f / 255, 193f / 255, 1f);
            // -----------------------------------------------
            float eCenterY = 0.6f;
            float seCenterX = 0.06f;

            DrawQuad(smallSize, eraserColor, seCenterX, eCenterY);

            float seLeftButtonEdge = seCenterX - (smallSize / 2);
            float seRightButtonEdge = seCenterX + (smallSize / 2);
            bool seHorizontalCondition = mousePositionX > seLeftButtonEdge && mousePositionX < seRightButtonEdge;

            float seBottomButtonEdge = eCenterY - (smallSize / 2);
            float seTopButtonEdge = eCenterY + (smallSize / 2);
            bool seVerticalCondition = mousePositionY > seBottomButtonEdge && mousePositionY < seTopButtonEdge;

            bool isSmallEraserClicked = seHorizontalCondition && seVerticalCondition;




            float meCenterX = 0.1f;

            DrawQuad(mediumSize, eraserColor, meCenterX, eCenterY);

            float meLeftButtonEdge = meCenterX - (mediumSize / 2);
            float meRightButtonEdge = meCenterX + (mediumSize / 2);
            bool meHorizontalCondition = mousePositionX > meLeftButtonEdge && mousePositionX < meRightButtonEdge;

            float meBottomButtonEdge = eCenterY - (mediumSize / 2);
            float meTopButtonEdge = eCenterY + (mediumSize / 2);
            bool meVerticalCondition = mousePositionY > meBottomButtonEdge && mousePositionY < meTopButtonEdge;

            bool isMediumEraserClicked = meHorizontalCondition && meVerticalCondition;




            float leCenterX = 0.15f;

            DrawQuad(largeSize, eraserColor, leCenterX, eCenterY);

            float leLeftButtonEdge = leCenterX - (largeSize / 2);
            float leRightButtonEdge = leCenterX + (largeSize / 2);
            bool leHorizontalCondition = mousePositionX > leLeftButtonEdge && mousePositionX < leRightButtonEdge;

            float leBottomButtonEdge = eCenterY - (largeSize / 2);
            float leTopButtonEdge = eCenterY + (largeSize / 2);
            bool leVerticalCondition = mousePositionY > leBottomButtonEdge && mousePositionY < leTopButtonEdge;

            bool isLargeEraserClicked = leHorizontalCondition && leVerticalCondition;
            // -----------------------------------------------
            // Toolbox Straight Line
            // -----------------------------------------------
            float quadLineCenterX = toolboxWidth / 2;
            float quadLineWidth = toolboxWidth * 0.8f;
            float lineThickness = 0.05f;
            float y = 0.45f;

            DrawQuadLine(quadLineWidth, quadLineCenterX, lineThickness, toolColor, y);

            float qlLeftButtonEdge = quadLineCenterX - (quadLineWidth / 2);
            float qlRightButtonEdge = quadLineCenterX + (quadLineWidth / 2);
            bool qlHorizontalCondition = mousePositionX > qlLeftButtonEdge && mousePositionX < qlRightButtonEdge;

            float qlBottomButtonEdge = y - (lineThickness / 2);
            float qlTopButtonEdge = y + (lineThickness / 2);
            bool qlVerticalCondition = mousePositionY > qlBottomButtonEdge && mousePositionY < qlTopButtonEdge;

            bool isQuadLineClicked = qlHorizontalCondition && qlVerticalCondition;
            // -----------------------------------------------
            // -----------------------------------------------
            // Toolbox Polygon Shape
            // -----------------------------------------------
            float shapeCenterX = toolboxWidth / 2;
            float shapeCenterY = 0.3f;
            float length = 0.15f;

            Color polygonSelectorBackgroundColor = Color.gray;
            DrawQuad(length, polygonSelectorBackgroundColor, shapeCenterX, shapeCenterY);

            DrawPolygon(shapeCenterX, shapeCenterY);

            float pLeftButtonEdge = shapeCenterX - (length / 2);
            float pRightButtonEdge = shapeCenterX + (length / 2);
            bool pHorizontalCondition = mousePositionX > pLeftButtonEdge && mousePositionX < pRightButtonEdge;

            float pBottomButtonEdge = shapeCenterY - (length / 2);
            float pTopButtonEdge = shapeCenterY + (length / 2);
            bool pVerticalCondition = mousePositionY > pBottomButtonEdge && mousePositionY < pTopButtonEdge;

            bool isPolygonClicked = pHorizontalCondition && pVerticalCondition;
            // -----------------------------------------------
            // -----------------------------------------------
            // Toolbox Color Selection
            // -----------------------------------------------
            float cCenterY = 0.1f;
            
            float crCenterX = 0.05f;
            DrawQuad(mediumSize, Color.red, crCenterX, cCenterY);

            float crLeftButtonEdge = crCenterX - (mediumSize / 2);
            float crRightButtonEdge = crCenterX + (mediumSize / 2);
            bool crHorizontalCondition = mousePositionX > crLeftButtonEdge && mousePositionX < crRightButtonEdge;

            float crBottomButtonEdge = cCenterY - (mediumSize / 2);
            float crTopButtonEdge = cCenterY + (mediumSize / 2);
            bool crVerticalCondition = mousePositionY > crBottomButtonEdge && mousePositionY < crTopButtonEdge;

            bool isRedSelected = crHorizontalCondition && crVerticalCondition;


            float cgCenterX = 0.1f;
            DrawQuad(mediumSize, Color.green, cgCenterX, cCenterY);

            float cgLeftButtonEdge = cgCenterX - (mediumSize / 2);
            float cgRightButtonEdge = cgCenterX + (mediumSize / 2);
            bool cgHorizontalCondition = mousePositionX > cgLeftButtonEdge && mousePositionX < cgRightButtonEdge;

            float cgBottomButtonEdge = cCenterY - (mediumSize / 2);
            float cgTopButtonEdge = cCenterY + (mediumSize / 2);
            bool cgVerticalCondition = mousePositionY > cgBottomButtonEdge && mousePositionY < cgTopButtonEdge;

            bool isGreenSelected = cgHorizontalCondition && cgVerticalCondition;


            float cbCenterX = 0.15f;
            DrawQuad(mediumSize, Color.blue, cbCenterX, cCenterY);

            float cbLeftButtonEdge = cbCenterX - (mediumSize / 2);
            float cbRightButtonEdge = cbCenterX + (mediumSize / 2);
            bool cbHorizontalCondition = mousePositionX > cbLeftButtonEdge && mousePositionX < cbRightButtonEdge;

            float cbBottomButtonEdge = cCenterY - (mediumSize / 2);
            float cbTopButtonEdge = cCenterY + (mediumSize / 2);
            bool cbVerticalCondition = mousePositionY > cbBottomButtonEdge && mousePositionY < cbTopButtonEdge;

            bool isBlueSelected = cbHorizontalCondition && cbVerticalCondition;
            // -----------------------------------------------

            if (isRedSelected)
            {
                Debug.Log("Red Color selected");
                currentPainterColor = Color.red;
            }
            else if (isGreenSelected)
            {
                Debug.Log("Green Color selected");
                currentPainterColor = Color.green;
            }
            else if (isBlueSelected) 
            {
                Debug.Log("Blue Color selected");
                currentPainterColor = Color.blue;
            }

            if (isOrganicLineClicked)
            {
                Debug.Log("(0) Organic Line selected");
                currentPainterMode = (int)PainterMode.OrganicLine;
            } 
            else if (isSmallQuadClicked)
            {
                Debug.Log("(1) Small Quad selected");
                currentPainterMode = (int)PainterMode.QuadBrush;
                currentPainterSize = (int)QuadSize.Small;
            }
            else if (isMediumQuadClicked)
            {
                Debug.Log("(1) Medium Quad selected");
                currentPainterMode = (int)PainterMode.QuadBrush;
                currentPainterSize = (int)QuadSize.Medium;
            }
            else if (isLargeQuadClicked)
            {
                Debug.Log("(1) Large Quad selected");
                currentPainterMode = (int)PainterMode.QuadBrush;
                currentPainterSize = (int)QuadSize.Large;
            }
            else if (isSmallEraserClicked)
            {
                Debug.Log("(2) Small Eraser selected");
                currentPainterMode = (int)PainterMode.QuadErase;
                currentPainterSize = (int)QuadSize.Small;
            }
            else if (isMediumEraserClicked)
            {
                Debug.Log("(2) Medium Eraser selected");
                currentPainterMode = (int)PainterMode.QuadErase;
                currentPainterSize = (int)QuadSize.Medium;
            }
            else if (isLargeEraserClicked)
            {
                Debug.Log("(2) Large Eraser selected");
                currentPainterMode = (int)PainterMode.QuadErase;
                currentPainterSize = (int)QuadSize.Large;
            }
            else if (isQuadLineClicked)
            {
                Debug.Log("(3) Straight Line selected");
                currentPainterMode = (int)PainterMode.StraightLine;
            }
            else if (isPolygonClicked)
            {
                Debug.Log("(4) Polygon selected");
                currentPainterMode = (int)PainterMode.Polygon;
            }



            return (currentPainterMode, currentPainterSize, currentPainterColor);
        }

        public void DrawCircle(float diameter, Color color, float centerX, float centerY)
        {

            float r = diameter / 2;

            float circleEdgeX;
            float circleEdgeY;

            float dx;
            float dy;

            Vector3 startingLinePoint = new Vector3(centerX, centerY, 0);

            // Draw a line, relative to each of the 360 angles, starting from the circle center to circleEdge...
            // Each line length can be found by finding the x and y coordinates of the circleEdge...
            // The resulting shape will be similar to a circle or oval depending on the window size.
            for (int i = 0; i < 360; i++) 
            {
                // ----------------------------------------------------
                // Finding the x and y coordinates of the circleEdge :
                // ----------------------------------------------------
                float radians = (float)(i * Math.PI / 180);

                dx = (float)(r * Math.Cos(radians));
                dy = (float)(r * Math.Sin(radians));

                circleEdgeX = centerX + dx;
                circleEdgeY = centerY + dy;
                // ----------------------------------------------------


                GL.Begin(GL.LINES);

                GL.Color(color);

                GL.Vertex(startingLinePoint);

                Vector3 endingLinePoint = new Vector3(circleEdgeX, circleEdgeY, 0);
                GL.Vertex(endingLinePoint);

                GL.End();
            }
        }
    
        public void DrawQuad(float length, Color color, float centerX, float centerY)
        {
            QuadBrush quadBrush = new QuadBrush();
            quadBrush.Draw(length, length, color, centerX, centerY);
        }    

        public void DrawQuadLine(float width, float lineCenterX, float lineThickness, Color color, float y)
        {
            QuadBrush quadBrush = new QuadBrush();
            quadBrush.Draw(lineThickness, width, color, lineCenterX, y);
        }

        public void DrawPolygon(float centerX, float centerY)
        {
            Polygon polygon = new Polygon();
            polygon.Draw(centerX, centerY);
        }
    
    }
}
