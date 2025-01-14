using System;
using System.Collections;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK3_StandardTemplate_WinForms.helpers;

namespace OpenTK3_StandardTemplate_WinForms.objects
{
    class Cube
    {
        private ArrayList coordinates;
        private ArrayList colors;
        private PolygonMode currentPolygonState = PolygonMode.Fill;
        private bool visibility;

        public Cube()
        {
            coordinates = new ArrayList
            {
                new Coords(0, 0, 0), // 0
                new Coords(1, 0, 0), // 1
                new Coords(1, 1, 0), // 2
                new Coords(0, 1, 0), // 3
                new Coords(0, 0, 1), // 4
                new Coords(1, 0, 1), // 5
                new Coords(1, 1, 1), // 6
                new Coords(0, 1, 1)  // 7
            };

            colors = new ArrayList();

            // Random colors for each face
            for (int i = 0; i < 6; i++)
            {
                colors.Add(Randomizer.GetRandomColor());
            }

            visibility = true;
        }

        public void Draw(bool useTexture = false, float alpha = 1.0f)
        {
            if (!visibility)
                return;

            GL.PolygonMode(MaterialFace.FrontAndBack, currentPolygonState);

            if (alpha < 1.0f)
            {
                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            }

            // Front face
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(((Color)colors[0]).R / 255.0f, ((Color)colors[0]).G / 255.0f, ((Color)colors[0]).B / 255.0f, alpha);
            for (int i = 0; i < 4; i++)
            {
                GL.Vertex3(((Coords)coordinates[i]).X, ((Coords)coordinates[i]).Y, ((Coords)coordinates[i]).Z);
            }
            GL.End();

            // Repeat for other faces...

            if (alpha < 1.0f)
            {
                GL.Disable(EnableCap.Blend);
            }
        }

        public void Scale(float scaleFactor)
        {
            for (int i = 0; i < coordinates.Count; i++)
            {
                Coords c = (Coords)coordinates[i];
                coordinates[i] = new Coords(c.X * scaleFactor, c.Y * scaleFactor, c.Z * scaleFactor);
            }
        }
    }
}
